using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Player")]
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
