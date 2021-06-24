using MafiaAPI.Models;
using MafiaAPI.Repositories;
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
        public AuthController(IBossRepository bossRepository, IPlayerRepository playerRepository, IAgentRepository agentRepository)
        {
            _playerRepository = playerRepository;
            _bossRepository = bossRepository;
            _agentRepository = agentRepository;
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
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
        public IActionResult Register([FromBody] RegisterModel user)
        {
            if(_bossRepository.IsBossWithThatLastName(user.BossLastName) == true)
            {
                return BadRequest("There is a boss with a such last name");
            }

            if (_playerRepository.IsPlayerWithThatNick(user.Nick) == true)
            {
                return BadRequest("There is a player with a such nick");
            }

            Boss boss = new Boss()
            {
                FirstName = user.BossFirstName,
                LastName = user.BossLastName,
                Money = 5000
            };
            _bossRepository.Post(boss);
            Player player = new Player()
            {
                Nick = user.Nick,
                Password = user.Password,
            };
            player.BossId = boss.BossId;
            _playerRepository.Post(player);

            Random random = new Random();

            foreach(var agentName in user.AgentNames)
            {
                var newAgent = new Agent()
                {
                    FirstName = agentName,
                    LastName = user.BossLastName,
                    Strength = random.Next(2, 5),
                    Income = random.Next(2, 5)*10,
                    BossId=boss.BossId
                };
                _agentRepository.Post(newAgent);
            }

            return Ok($"New player created\n{player.Nick}, your journey begin. You get 3 agents and 5000$ for the start.");
        }
    }
}
