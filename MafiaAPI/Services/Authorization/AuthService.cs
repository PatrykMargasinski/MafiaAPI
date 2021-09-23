using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Util;
using MafiaAPI.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MafiaAPI.Services
{

    public class AuthService : IAuthService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IBossRepository _bossRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IPerformingMissionRepository _performingMissionRepository;
        private readonly IConfiguration _config;
        private readonly ISecurityService _securityService;

        public AuthService(
            IPlayerRepository playerRepository,
            IBossRepository bossRepository,
            IAgentRepository agentRepository,
            IPerformingMissionRepository performingMissionRepository,
            ISecurityService securityService,
            IConfiguration config
            )
        {
            _playerRepository = playerRepository;
            _bossRepository = bossRepository;
            _agentRepository = agentRepository;
            _performingMissionRepository = performingMissionRepository;
            _securityService = securityService;
            _config = config;
        }

        public string[] LoginValidation(LoginDto user)
        {
            var validator = new LoginValidator();
            var errors = validator.Validate(user);
            try
            {
                if (errors.Length > 0)
                {
                    return errors;
                }

                Player player = _playerRepository.GetByNick(user.Nick);
                if (player == null)
                {
                    return new string[] { "There is no player with such nick" };
                }

                if (VerifyPassword(player, user.Password) == false)
                {
                    return new string[] { "Wrong password" };
                }
                return errors;
            }
            catch (SqlException)
            {
                return new string[] { "There is a problem with a database" };
            }
            catch (Exception ex)
            {
                return new string[] { "Something happened: " + ex.Message };
            }
        }

        public string CreateToken(string user)
        {
            var key = _config.GetValue<string>("Security:AuthKey");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, "Player")
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:53191",
                audience: "http://localhost:53191",
                expires: DateTime.Now.AddMinutes(5),
                claims: claims,
                signingCredentials: signingCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }


        public string[] RegisterValidation(RegisterDTO user)
        {
            var validator = new RegisterValidator();
            var errors = validator.Validate(user);
            if (errors.Length > 0)
            {
                return errors;
            }
            if (_bossRepository.IsBossWithThatLastName(user.BossLastName) == true)
            {
                return new string[] { "There is a boss with a such last name" };
            }

            if (_playerRepository.IsPlayerWithThatNick(user.Nick) == true)
            {
                return new string[] { "There is a player with a such nick" };
            }
            return errors;
        }

        public void CreateUser(RegisterDTO user)
        {
            Boss boss = new Boss()
            {
                FirstName = Utils.UppercaseFirst(user.BossFirstName),
                LastName = Utils.UppercaseFirst(user.BossLastName),
                Money = 5000
            };
            _bossRepository.Update(boss);
            Player player = new Player()
            {
                Nick = user.Nick,
                Password = _securityService.Hash(user.Password),
            };
            player.BossId = boss.Id;
            _playerRepository.Create(player);

            Random random = new Random();

            foreach (var agentName in user.AgentNames)
            {
                var newAgent = new Agent()
                {
                    FirstName = Utils.UppercaseFirst(agentName),
                    LastName = Utils.UppercaseFirst(user.BossLastName),
                    Strength = random.Next(2, 5),
                    Intelligence = random.Next(2, 5),
                    Dexterity = random.Next(2, 5),
                    Income = random.Next(2, 5) * 10,
                    BossId = boss.Id
                };
                _agentRepository.Create(newAgent);
            }
        }

        public string[] DeleteAccount(long playerId)
        {
            Player deletingPlayer = _playerRepository.GetWithBoss(playerId);
            if (deletingPlayer == null)
                return new string[] { "There is no player with such id" };
            Boss boss = deletingPlayer.Boss;
            var agents = _agentRepository.GetBossAgents(boss.Id).ToArray();
            foreach (var agent in agents)
            {
                var performingMissionIds = _performingMissionRepository.GetByAgentId(agent.Id).Select(x => x.Id).ToArray();
                foreach (var id in performingMissionIds)
                {
                    _performingMissionRepository.DeleteById(id);
                }
            }
            foreach (var id in agents.Select(x => x.Id))
            {
                _agentRepository.DeleteById(id);
            }
            _playerRepository.DeleteById(playerId);
            _bossRepository.DeleteById(boss.Id);
            return Array.Empty<string>();
        }

        public bool VerifyPassword(Player player, string pass)
        {
            string savedPasswordHash = player.Password;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }

        public string[] ChangePassword(ChangePasswordDTO changeModel)
        {
            Player player = _playerRepository.GetById(changeModel.PlayerId);
            if (player == null)
            {
                return new string[] { "User not found" };
            }

            if (VerifyPassword(player, changeModel.OldPassword) == false)
            {
                return new string[] { "Invalid old password" };
            }
            try
            {
                player.Password = _securityService.Hash(changeModel.NewPassword);
            }
            catch (Exception)
            {
                return new string[] { "Error occurred during hashing operation" };
            }

            _playerRepository.Update(player);

            return Array.Empty<string>();
        }
    }
}
