using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class MissionRepository : CrudRepository<Mission>, IMissionRepository
    {

        public MissionRepository(MafiaDBContext context): base(context){}

        public IEnumerable<Mission> GetAvailableMissions()
        {
            return _context.Missions.Where(mission => mission.PerformingMissions.Count == 0);
        }

    }
}
