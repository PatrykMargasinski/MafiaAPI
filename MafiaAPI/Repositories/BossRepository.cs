using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class BossRepository : IBossRepository
    {
        private readonly MafiaDBContext _context;

        public BossRepository(MafiaDBContext context)
        {
            _context = context;
        }

        public void Update(Boss newBoss)
        {
            var updatingBoss = _context.Bosses.FirstOrDefault(boss => boss.BossId == newBoss.BossId);
            if (newBoss != null && updatingBoss != null)
            {
                updatingBoss.FirstName = newBoss.FirstName;
                updatingBoss.LastName = newBoss.LastName;
                updatingBoss.Money= newBoss.Money;
                updatingBoss.LastName = DateTime.Now.ToString();
                _context.SaveChanges();
            }
        }

        public Boss Get()
        {
            var boss = _context.Bosses.First();
            boss.LastSeen = DateTime.Now;
            _context.SaveChanges();
            return _context.Bosses.First();
        }
    }
}
