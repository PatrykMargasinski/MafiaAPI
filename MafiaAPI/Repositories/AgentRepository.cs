using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class AgentRepository : IAgentRepository
    {
        private readonly MafiaDBContext _context;

        public AgentRepository(MafiaDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Agent> GetAvailableAgents(int bossId)
        {
            return _context.Agents.Where(agent => agent.PerformingMissions.Count == 0 && agent.BossId == bossId);
        }

        public IEnumerable<Agent> GetBossAgents(int bossId)
        {
            return _context.Agents.Where(agent => agent.BossId == bossId);
        }

        public IEnumerable<Agent> GetAgentsForRecruitment()
        {
            return _context.Agents.Where(agent => agent.BossId == null);
        }

        public Agent Get(int id)
        {
            return _context.Agents.FirstOrDefault(agent => agent.AgentId == id);
        }

        public IEnumerable<Agent> GetAll()
        {
            return _context.Agents;
        }

        public void Post(Agent agent)
        {
            if(agent!=null)
            {
                _context.Agents.Add(agent);
                _context.SaveChanges();
            }
        }

        public void Update(Agent newAgent)
        {
            var updatingAgent = _context.Agents.FirstOrDefault(agent => agent.AgentId == newAgent.AgentId);
            if (newAgent!=null && updatingAgent!=null)
            {
                updatingAgent.BossId = newAgent.BossId;
                updatingAgent.Boss = newAgent.Boss;
                updatingAgent.FirstName = newAgent.FirstName;
                updatingAgent.LastName = newAgent.LastName;
                updatingAgent.Income = newAgent.Income;
                updatingAgent.Strength = newAgent.Strength;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var deletingAgent = _context.Agents.FirstOrDefault(agent => agent.AgentId == id);
            _context.Remove(deletingAgent);
            _context.SaveChanges();
        }
    }
}
