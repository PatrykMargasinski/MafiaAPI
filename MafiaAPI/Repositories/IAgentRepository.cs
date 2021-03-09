using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IAgentRepository
    {
        public IEnumerable<Agent> GetAll();
        public IEnumerable<Agent> GetAvailableAgents();
        public IEnumerable<Agent> GetAgentsForRecruitment();
        public Agent Get(int id);
        public void Post(Agent agent);
        public void Update(Agent newAgent);
        public void Delete(int id);
    }
}
