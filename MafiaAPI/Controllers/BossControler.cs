using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BossController : Controller
    {
        private readonly BossRepository _bossRepository;
        public BossController(BossRepository bossRepository)
        {
            _bossRepository = bossRepository;
        }

        [Route("/boss/{id:int}")]
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var boss = _bossRepository.getById(id);
            return new JsonResult(boss);
        }

        [Route("/boss/GetNameById/{name}")]
        [HttpGet("{name}")]
        public IActionResult GetBossIdByName(string name)
        {
            var boss = _bossRepository.GetByName(name);
            if(boss == null)
            {
                return BadRequest("Boss not found");
            }
            else
            {
                return Ok(boss.BossId);
            }
        }

        [HttpPost]
        public JsonResult Post(Boss boss)
        {
            _bossRepository.create(boss);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Boss boss)
        {
            _bossRepository.update(boss);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete]
        public JsonResult Delete(long id)
        {
            _bossRepository.deleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
