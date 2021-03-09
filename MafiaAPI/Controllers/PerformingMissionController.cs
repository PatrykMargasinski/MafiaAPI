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
    public class PerformingMissionController : Controller
    {
        private readonly IPerformingMissionRepository _performingMissionRepository;
        public PerformingMissionController(IPerformingMissionRepository performingMissionRepository)
        {
            _performingMissionRepository = performingMissionRepository;
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        [HttpGet]
        public JsonResult Get(int id)
        {
            var performingMission = _performingMissionRepository.Get(id);
            return new JsonResult(performingMission);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var performingMissions = _performingMissionRepository.GetAll();
            return new JsonResult(performingMissions);
        }

        [HttpPut]
        public JsonResult Update(PerformingMission performingMission)
        {
            _performingMissionRepository.Update(performingMission);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _performingMissionRepository.Delete(id);
            return new JsonResult("Deleted successfully");
        }

    }
}
