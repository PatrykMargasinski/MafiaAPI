using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IAgentRepository
    {
        public IEnumerable<Agent> GetAvailableAgents(int bossId);
        public IEnumerable<Agent> GetAgentsForRecruitment();
    }
}
