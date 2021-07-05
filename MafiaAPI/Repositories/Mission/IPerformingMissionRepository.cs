﻿using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPerformingMissionRepository: ICrudRepository<PerformingMission>
    {
        public IEnumerable<PerformingMission> GetByAgentId(long id);
        public IQueryable<PerformingMission> GetAllWithMissionAndAgent();
        public IQueryable<PerformingMission> GetAllWithMissionAndAgentByBossId(long bossId);
    }
}
