using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost]
        public JsonResult Post(Player player)
        {
            _playerRepository.Create(player);
            return new JsonResult("Added succesfully");
        }

        /// <summary>
        /// Get player with id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            var player = _playerRepository.GetById(id);
            return new JsonResult(player);
        }

        [HttpPut]
        public JsonResult Update(Player player)
        {
            _playerRepository.Update(player);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _playerRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
