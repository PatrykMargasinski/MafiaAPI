using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IAgentRepository: ICrudRepository<Agent>
    {
        public IList<Agent> GetAvailableAgents(long bossId);
        public IList<Agent> GetAgentsForRecruitment();
        public IList<Agent> GetBossAgents(long id);
    }
}
