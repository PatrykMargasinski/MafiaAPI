using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaAPI.Database;
using MafiaAPI.Repositories;
using MafiaAPI.Validators;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using MafiaAPI.Util;

namespace MafiaAPI.Services
{

    public class AuthService : IAuthService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IBossRepository _bossRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IPerformingMissionRepository _performingMissionRepository;

        public AuthService(
            IPlayerRepository playerRepository, 
            IBossRepository bossRepository, 
            IAgentRepository agentRepository, 
            IPerformingMissionRepository performingMissionRepository
            )
        {
            _playerRepository = playerRepository;
            _bossRepository = bossRepository;
            _agentRepository = agentRepository;
            _performingMissionRepository = performingMissionRepository;
        }

        public string[] LoginValidation(LoginDto user)
        {
            var validator = new LoginValidator();
            var errors = validator.Validate(user);
            if (errors.Length > 0)
            {
                return errors;
            }

            Player player = _playerRepository.GetByNick(user.Nick);
            if (player == null || player.Password != user.Password)
            {
                return new string[] { "Wrong nick or password" };
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JavorJestNajepszy"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:53191",
                audience: "http://localhost:53191",
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return errors;
        }

        public string CreateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JavorJestNajepszy"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:53191",
                audience: "http://localhost:53191",
                expires: DateTime.Now.AddMinutes(5),
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
                Password = user.Password,
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
    }
}
