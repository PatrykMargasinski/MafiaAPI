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

        public IEnumerable<Agent> GetAvailableAgents(long bossId){
            return _context.Agents.Where(agent => agent.PerformingMissions.Count == 0 && agent.BossId == bossId);
        }

        public IEnumerable<Agent> GetAgentsForRecruitment(){
            return _context.Agents.Where(agent => agent.BossId == null);
        }

        public IEnumerable<Agent> GetBossAgents(long id)
        {
            return _context.Agents.Where(agent => agent.BossId == id);
        }
    }
}
