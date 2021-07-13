using MafiaAPI.Models;
using MafiaAPI.Models.DTO;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
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

        /// <summary>
        /// Get all missions in progress started by boss with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var performingMission = _performingMissionRepository.GetById(id);
            return new JsonResult(new PerformingMissionDTO(performingMission));
        }

        [HttpGet]
        public JsonResult GetAll(long? bossId)
        {
            if (bossId.HasValue)
            {
                return GetAllByBossId(bossId.Value);
            }
            return GetAllInProgress();
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

        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _performingMissionRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }

        private JsonResult GetAllInProgress()
        {
            return new JsonResult(
                _performingMissionRepository.GetAllWithMissionAndAgent()
                .Select(mission => new PerformingMissionDTO(mission))
            );
        }

        private JsonResult GetAllByBossId(long bossId)
        {
            return new JsonResult(
                    _performingMissionRepository
                    .GetAllWithMissionAndAgentByBossId(bossId)
                    .Select(mission => new PerformingMissionDTO(mission)));
        }
    }
}
