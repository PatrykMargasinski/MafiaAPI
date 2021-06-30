using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        private readonly MissionRepository _missionRepository;
        public MissionController(MissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            var mission = _missionRepository.getById(id);
            return new JsonResult(mission);
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetAll()
        {
            var missions = _missionRepository.getAll();
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
            _missionRepository.update(mission);
            return new JsonResult("Updated successfully");
        }

        [HttpPost]
        public JsonResult Create(Mission mission)
        {
            _missionRepository.create(mission);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _missionRepository.deleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
