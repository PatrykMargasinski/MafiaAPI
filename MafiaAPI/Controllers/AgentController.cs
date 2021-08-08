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
    [Authorize(Roles = "Player")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepository;
        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpGet("available/{bossId}")]
        public JsonResult GetAvailableAgents(int bossId)
        {
            var agents = _agentRepository.GetAvailableAgents(bossId);
            return new JsonResult(agents);
        }

        [HttpGet("onMission/{bossId}")]
        public JsonResult GetAgentsOnMission(int bossId)
        {
            var agents = _agentRepository.GetAgentsOnMission(bossId);
            return new JsonResult(agents);
        }

        [HttpGet("forSale")]
        public JsonResult GetAgentsForSale()
        {
            var agents = _agentRepository.GetAgentsForSale();
            return new JsonResult(agents);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var agent = _agentRepository.GetById(id);
            return new JsonResult(agent);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var agents = _agentRepository.GetAll();
            return new JsonResult(agents);
        }


        [HttpPost]
        public JsonResult AddAgent(Agent agent)
        {
            _agentRepository.Create(agent);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Agent agent)
        {
            _agentRepository.Update(agent);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _agentRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
