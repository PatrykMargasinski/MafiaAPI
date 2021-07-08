using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaAPI.Database;

namespace MafiaAPI.Repositories
{
    
    public class AgentRepository : CrudRepository<Agent> ,IAgentRepository
    {

        public AgentRepository(MafiaDBContext context): base(context){}

        public IList<Agent> GetAvailableAgents(long bossId){
            return _context.Agents
                .Where(agent => !agent.PerformingMissions.Any() && agent.BossId == bossId)
                .ToList();
        }

        public IList<Agent> GetAgentsForRecruitment(){
            return _context.Agents
                .Where(agent => agent.BossId == null)
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
