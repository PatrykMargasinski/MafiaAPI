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
        private readonly IBossRepository _bossRepository;
        public BossController(IBossRepository bossRepository)
        {
            _bossRepository = bossRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var boss = _bossRepository.Get();
            return new JsonResult(boss);
        }

        [HttpPut]
        public JsonResult Update(Boss boss)
        {
            _bossRepository.Update(boss);
            return new JsonResult("Updated successfully");
        }

    }
}
