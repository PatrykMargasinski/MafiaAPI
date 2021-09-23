using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{
    public interface IPerformingMissionRepository : ICrudRepository<PerformingMission>
    {
        public IList<PerformingMission> GetByAgentId(long id);
        public IList<PerformingMission> GetAllWithMissionAndAgent();
        public IList<PerformingMission> GetAllWithMissionAndAgentByBossId(long bossId);
    }
}
