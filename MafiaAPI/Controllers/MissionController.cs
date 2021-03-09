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
    public class MissionController : Controller
    {
        private readonly IMissionRepository _missionRepository;
        public MissionController(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var mission = _missionRepository.Get(id);
            return new JsonResult(mission);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var missions = _missionRepository.GetAll();
            return new JsonResult(missions);
        }
        
        [Route("/GetAvailableMissions")]
        [HttpGet]
        public JsonResult GetAvailableMissions()
        {
            var missions = _missionRepository.GetAvailableMissions();
            return new JsonResult(missions);
        }

        [HttpPut]
        public JsonResult Update(Mission mission)
        {
            _missionRepository.Update(mission);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _missionRepository.Delete(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
