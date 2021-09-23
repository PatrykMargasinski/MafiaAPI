using MafiaAPI.Database;
using MafiaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class AgentRepository : CrudRepository<Agent>, IAgentRepository
    {

        public AgentRepository(MafiaDBContext context) : base(context) { }

        public IList<Agent> GetAvailableAgents(long bossId)
        {
            return _context.Agents
                .Where(agent => !agent.PerformingMissions.Any() && agent.BossId == bossId)
                .ToList();
        }

        public IList<Agent> GetAgentsForSale()
        {
            return _context.Agents
                .Where(agent => agent.BossId == null)
                .ToList();
        }

        public IList<Agent> GetAgentsOnMission(long bossId)
        {
            return _context
                .Agents
                .Where(agent => _context.PerformingMissions.Any(pm => pm.AgentId == agent.Id) && agent.BossId == bossId)
                .ToList();
        }

        public IList<Agent> GetBossAgents(long id)
        {
            return _context.Agents
                .Where(agent => agent.BossId == id)
                .ToList();
        }
    }
}
