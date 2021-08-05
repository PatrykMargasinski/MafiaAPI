using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Service;
using Microsoft.AspNetCore.Mvc;
using MafiaAPI.Models.Requests;
using Microsoft.AspNetCore.Authorization;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Player")]
    [ApiController]
    public class MissionController : Controller
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMissionService _missionService;
        private readonly IPerformingMissionService _pmService;
        private readonly IAgentService _agentService;

        public MissionController(
            IMissionRepository missionRepository,
            IMissionService missionService,
            IPerformingMissionService pmService,
            IAgentService agentService)
        {
            _missionRepository = missionRepository;
            _missionService = missionService;
            _pmService = pmService;
            _agentService = agentService;
        }

        [Route("id")]
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            return new JsonResult(_missionRepository.GetById(id));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_missionRepository.GetAll());
        }

        [Route("GetAvailableMissions")]
        [HttpGet]
        public JsonResult GetAvailableMissions()
        {
            return new JsonResult(_missionRepository.GetAvailableMissions());
        }

        [HttpPut]
        public JsonResult Update(Mission mission)
        {
            _missionRepository.Update(mission);
            return new JsonResult("Updated successfully");
        }

        [HttpPost]
        public JsonResult Create(Mission mission)
        {
            _missionRepository.Create(mission);
            return new JsonResult("Updated successfully");
        }

        [Route("id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _missionRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }

        [Route("start")]
        [HttpPost]
        public IActionResult startMission([FromBody] MissionStartRequest missionStart)
        {
            long agentId = missionStart.AgentId;
            long missionId = missionStart.MissionId;
            return _missionService.DoMission(agentId, missionId);
        }
    }
}
