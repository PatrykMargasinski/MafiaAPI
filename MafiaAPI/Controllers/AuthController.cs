using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Services.Authorization;
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
        private readonly IAuthService _authService;

        public AuthController(IPlayerRepository playerRepository,
                              IAuthService authService)
        {
            _playerRepository = playerRepository;
            _authService = authService;
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto user)
        {
            var errors = _authService.LoginValidation(user);
            if(errors.Length>0)
                return BadRequest(string.Join('\n', errors));
            else
                return Ok(new 
                { 
                    Token = _authService.CreateToken(), 
                    BossId = _playerRepository.GetByNick(user.Nick).BossId
                });
        }

        [Route("/register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterDTO user)
        {
            var errors = _authService.RegisterValidation(user);
            if (errors.Length > 0)
                return BadRequest(string.Join('\n', errors));
            else
            {
                _authService.CreateUser(user);
                return Ok();
            }
        }

        [Route("/deleteAccount/{playerId:long}")]
        [HttpDelete]
        public IActionResult DeleteAccount(long playerId)
        {
            var errors = _authService.DeleteAccount(playerId);
            if (errors.Length > 0)
                return BadRequest(string.Join('\n', errors));
            else
            {
                return Ok();
            }
        }
    }
}