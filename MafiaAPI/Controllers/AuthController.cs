using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Util;
using MafiaAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IBossRepository _bossRepository;
        private readonly IAgentRepository _agentRepository;

        private readonly IPerformingMissionRepository _performingMissionRepository;
        public AuthController(IBossRepository bossRepository,
                              IPlayerRepository playerRepository,
                              IAgentRepository agentRepository,
                              IPerformingMissionRepository performingMissionRepository)
        {
            _playerRepository = playerRepository;
            _bossRepository = bossRepository;
            _agentRepository = agentRepository;
            _performingMissionRepository = performingMissionRepository;
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto user)
        {
            var validator = new LoginValidator();
            var errors = validator.Validate(user);
            if (errors.Length > 0)
            {
                return BadRequest(string.Join('\n', errors));
            }

            Player player = _playerRepository.GetByNick(user.Nick);
            if (player == null || player.Password != user.Password)
            {
                return Unauthorized();
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
            return Ok(new { Token = tokenString, BossId = player.BossId });
        }

        [Route("/register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterDTO user)
        {
            var validator = new RegisterValidator();
            var errors = validator.Validate(user);
            if (errors.Length > 0)
            {
                return BadRequest(string.Join('\n', errors));
            }
            if (_bossRepository.IsBossWithThatLastName(user.BossLastName) == true)
            {
                return BadRequest("There is a boss with a such last name");
            }

            if (_playerRepository.IsPlayerWithThatNick(user.Nick) == true)
            {
                return BadRequest("There is a player with a such nick");
            }

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
                    Income = random.Next(2, 5) * 10,
                    BossId = boss.Id
                };
                _agentRepository.Create(newAgent);
            }
            return Ok();
        }


        [Route("/deleteAccount/{playerId:int}")]
        [HttpDelete]
        public IActionResult DeleteAccount(int playerId)
        {
            Player deletingPlayer = _playerRepository.GetWithBoss(playerId);
            if (deletingPlayer == null)
                return BadRequest("There is no player with such id");
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
            return Ok();
        }
    }
}