﻿using System;
using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        [Route("{id}")]
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var boss = _bossRepository.GetById(id);
            return new JsonResult(boss);
        }

        [Route("{name}/id")]
        [HttpGet]
        public IActionResult GetIdByFullname(string name)
        {
            var boss = _bossRepository.GetByFullname(name);
            if (boss == null)
                return BadRequest("Boss with that name not found");
            return new JsonResult(boss.Id);
        }

        [HttpGet("similarNames")]
        public JsonResult GetSimilarNames(string name)
        {
            var similarNames = _bossRepository.GetSimilarNames(name.ToLower().Replace(" ", ""));
            return new JsonResult(similarNames);
        }

        [HttpPost]
        public JsonResult Post(Boss boss)
        {
            _bossRepository.Create(boss);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Boss boss)
        {
            _bossRepository.Update(boss);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete]
        public JsonResult Delete(long id)
        {
            _bossRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }

    }
}
