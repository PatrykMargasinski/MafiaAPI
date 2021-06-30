using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class MissionRepository : IMissionRepository
    {
        private readonly MafiaDBContext _context;

        public MissionRepository(MafiaDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Mission> GetAvailableMissions()
        {
            return _context.Missions.Where(mission => mission.PerformingMissions.Count == 0);
        }

        public Mission Get(int id)
        {
            return _context.Missions.FirstOrDefault(Mission => Mission.MissionId == id);
        }

        public IEnumerable<Mission> GetAll()
        {
            return _context.Missions;
        }

        public void Post(Mission mission)
        {
            if(mission!=null)
            {
                _context.Missions.Add(mission);
                _context.SaveChanges();
            }
        }

        public void Update(Mission newMission)
        {
            var updatingMission = _context.Missions.FirstOrDefault(mission => mission.MissionId == newMission.MissionId);
            if (newMission!=null && updatingMission!=null)
            {
                updatingMission.MissionName= newMission.MissionName;
                updatingMission.DifficultyLevel = newMission.DifficultyLevel;
                updatingMission.Loot = newMission.Loot;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var deletingMission = _context.Missions.FirstOrDefault(mission => mission.MissionId == id);
            _context.Remove(deletingMission);
            _context.SaveChanges();
        }
    }
}
