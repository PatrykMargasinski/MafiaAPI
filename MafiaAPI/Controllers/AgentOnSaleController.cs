using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Service;
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
    public class AgentForSaleController : Controller
    {
        private readonly IAgentForSaleRepository _agentForSaleRepository;
        private readonly IAgentService _agentService;
        public AgentForSaleController(IAgentForSaleRepository agentForSaleRepository, IAgentService agentService)
        {
            _agentForSaleRepository = agentForSaleRepository;
            _agentService = agentService;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var agent = _agentForSaleRepository.GetById(id);
            return new JsonResult(agent);
        }

        [HttpGet]
        public JsonResult GetAgentsForSale()
        {
            var agents = _agentForSaleRepository.GetAgentsForSale();
            return new JsonResult(agents);
        }


        [HttpGet("recruit")]
        public JsonResult RecruitAgent(long bossId, long agentId)
        {
            var text = _agentService.RecruitAgent(bossId, agentId);
            return new JsonResult(text);
        }
    }
}
