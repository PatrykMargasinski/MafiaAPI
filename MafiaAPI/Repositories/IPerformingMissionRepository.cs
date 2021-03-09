using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPerformingMissionRepository
    {
        public IEnumerable<PerformingMission> GetAll();
        public PerformingMission Get(int id);
        public void Post(PerformingMission agent);
        public void Update(PerformingMission newMission);
        public void Delete(int id);
    }
}
