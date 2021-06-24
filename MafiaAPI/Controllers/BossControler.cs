﻿using MafiaAPI.Models;
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

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var boss = _bossRepository.GetById(id);
            return new JsonResult(boss);
        }

        [HttpPost]
        public JsonResult Post(Boss boss)
        {
            _bossRepository.Post(boss);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Boss boss)
        {
            _bossRepository.Update(boss);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _bossRepository.Delete(id);
            return new JsonResult("Deleted successfully");
        }

    }
}
