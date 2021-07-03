using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public static object PerformingMissionToSend(PerformingMission performingMission)
        {
            return new
            {
                PerformingMissionId = performingMission.Id,
                MissionName = performingMission.Mission.Name,
                AgentName = performingMission.Agent.LastName + " " + performingMission.Agent.FirstName,
                ChanceOfSuccess = (int)((11f - performingMission.Mission.DifficultyLevel + performingMission.Agent.Strength + 1f) / 22f * 100),
                CompletionTime = performingMission.CompletionTime
            };
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var performingMission = _performingMissionRepository.GetById(id);
            return new JsonResult(PerformingMissionToSend(performingMission));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var performingMissions = _performingMissionRepository.GetAll().Select(mission => PerformingMissionToSend(mission));
            return new JsonResult(performingMissions);
        }

        [HttpPost]
        public JsonResult PerformMission(PerformingMission performingMission)
        {
            _performingMissionRepository.Create(performingMission);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(PerformingMission performingMission)
        {
            _performingMissionRepository.Update(performingMission);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _performingMissionRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }

    }
}
