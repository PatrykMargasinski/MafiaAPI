using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Repositories
{
    
    public class PerformingMissionRepository : CrudRepository<PerformingMission>, IPerformingMissionRepository
    {
    

        public PerformingMissionRepository(MafiaDBContext context): base(context){}
        
        public PerformingMission getById(long id)
        {
            return _context.PerformingMissions
                .Include(p=>p.Mission)
                .Include(p => p.Agent)
                .FirstOrDefault(PerformingMission => PerformingMission.id == id);
        }

        public IQueryable<PerformingMission> getAll()
        {
            return _context.PerformingMissions
                .Include(p => p.Mission)
                .Include(p => p.Agent);
        }
    }
}
