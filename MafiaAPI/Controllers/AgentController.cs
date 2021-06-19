﻿using MafiaAPI.Models;
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
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepository;
        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [Route("[controller]/id")]
        [HttpGet("{id}")]
        [Authorize]
        public JsonResult Get(int id)
        {
            var agent = _agentRepository.Get(id);
            return new JsonResult(agent);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var agents = _agentRepository.GetAll();
            return new JsonResult(agents);
        }
        
        [Route("/GetAvailableAgents")]
        [HttpGet]
        public JsonResult GetAvailableAgents()
        {
            var agents = _agentRepository.GetAvailableAgents();
            return new JsonResult(agents);
        }

        [Route("/GetAgentsForRecruitment")]
        [HttpGet]
        public JsonResult GetAgentsForRecruitment()
        {
            var agents = _agentRepository.GetAgentsForRecruitment();
            return new JsonResult(agents);
        }

        [HttpPost]
        public JsonResult AddAgent(Agent agent)
        {
            _agentRepository.Post(agent);
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Agent agent)
        {
            _agentRepository.Update(agent);
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _agentRepository.Delete(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
