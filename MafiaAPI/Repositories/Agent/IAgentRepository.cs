using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IAgentRepository: ICrudRepository<Agent>
    {
        public IEnumerable<Agent> GetAvailableAgents(long bossId);
        public IEnumerable<Agent> GetAgentsForRecruitment();
    }
}
