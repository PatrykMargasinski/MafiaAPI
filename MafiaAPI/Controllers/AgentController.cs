using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepository;
        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        
        /// <summary>
        /// Get available agents for boss who are not on mission
        /// </summary>
        /// <param name="bossId"></param>   
        [HttpGet("available/{bossId}")]
        public JsonResult GetAvailableAgents(int bossId)
        {
            var agents = _agentRepository.GetAvailableAgents(bossId);
            return new JsonResult(agents);
        }

        /// <summary>
        /// Get agent by id
        /// </summary>
        /// <param name="id"></param>   
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var agent = _agentRepository.GetById(id);
            return new JsonResult(agent);
        }


        /// <summary>
        /// Get all agents
        /// </summary> 
        [HttpGet]
        public JsonResult GetAll()
        {
            var agents = _agentRepository.GetAll();
            var temp = agents
                .Where(x => x.PerformingMissions.Any())
                .Select(x => new { x.FirstName, x.LastName });
            return new JsonResult(agents);
        }

        /// <summary>
        /// Get agents who dont have boss
        /// </summary>  
        [HttpGet("getAgentsForRecruitment")]
        public JsonResult GetAgentsForRecruitment()
        {
            var agents = _agentRepository.GetAgentsForRecruitment();
            return new JsonResult(agents);
        }


        /// <summary>
        /// Create new agent
        /// </summary>  
        [HttpPost]
        public JsonResult AddAgent(Agent agent)
        {
            _agentRepository.Create(agent);
            return new JsonResult("Added successfully");
        }

        /// <summary>
        /// Update agent
        /// </summary> 
        [HttpPut]
        public JsonResult Update(Agent agent)
        {
            _agentRepository.Update(agent);
            return new JsonResult("Updated successfully");
        }

        /// <summary>
        /// Delete agent
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            _agentRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
