using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPerformingMissionRepository
    {
        public IQueryable<PerformingMission> GetAll();
        public IEnumerable<PerformingMission> GetByAgentId(int id);
        public IEnumerable<PerformingMission> GetByMissionId(int id);
        public PerformingMission Get(int id);
        public void Post(PerformingMission agent);
        public void Update(PerformingMission newMission);
        public void Delete(int id);
    }
}
