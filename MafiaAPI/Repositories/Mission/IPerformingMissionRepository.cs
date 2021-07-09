using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPerformingMissionRepository: ICrudRepository<PerformingMission>
    {
        public IList<PerformingMission> GetByAgentId(long id);
        public IList<PerformingMission> GetAllWithMissionAndAgent();
        public IList<PerformingMission> GetAllWithMissionAndAgentByBossId(long bossId);
    }
}
