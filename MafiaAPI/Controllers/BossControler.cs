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
        public JsonResult GetIdByFullname(string name)
        {
            Console.WriteLine(name + " HELLO!");
            var boss = _bossRepository.GetByFullname(name);
            return new JsonResult(boss.Id);
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
