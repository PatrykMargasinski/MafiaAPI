﻿using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformingMissionController : Controller
    {
        private readonly PerformingMissionRepository _performingMissionRepository;
        public PerformingMissionController(PerformingMissionRepository performingMissionRepository)
        {
            _performingMissionRepository = performingMissionRepository;
        }

        public static object PerformingMissionToSend(PerformingMission performingMission)
        {
            return new
            {
                PerformingMissionId = performingMission.id,
                MissionName = performingMission.Mission.MissionName,
                AgentName = performingMission.Agent.LastName + " " + performingMission.Agent.FirstName,
                ChanceOfSuccess = (int)((11f - performingMission.Mission.DifficultyLevel + performingMission.Agent.Strength + 1f) / 22f * 100),
                CompletionTime = performingMission.CompletionTime
            };
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var performingMission = _performingMissionRepository.getById(id);
            return new JsonResult(PerformingMissionToSend(performingMission));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var performingMissions = _performingMissionRepository.getAll().Select(mission=>PerformingMissionToSend(mission));
            return new JsonResult(performingMissions);
        }

        [HttpPost]
        public JsonResult PerformMission(PerformingMission performingMission)
        {
            _performingMissionRepository.create(performingMission);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(PerformingMission performingMission)
        {
            _performingMissionRepository.update(performingMission);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _performingMissionRepository.deleteById(id);
            return new JsonResult("Deleted successfully");
        }

    }
}
