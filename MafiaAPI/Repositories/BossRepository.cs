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

        public Boss GetById(int id)
        {
            var boss = _context.Bosses.Where(x=>x.BossId==id).FirstOrDefault();
            boss.LastSeen = DateTime.Now;
            _context.SaveChanges();
            return boss;
        }

        public void Post(Boss boss)
        {
            if (boss != null)
            {
                _context.Bosses.Add(boss);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var deletingBoss = _context.Bosses.FirstOrDefault(boss => boss.BossId == id);
            _context.Remove(deletingBoss);
            _context.SaveChanges();
        }

        public Boss GetByFirstAndLastname(string firstname, string lastname)
        {
            var boss = _context.Bosses.FirstOrDefault(boss => boss.FirstName==firstname && boss.LastName==lastname);
            return boss;
        }

        public bool IsBossWithThatLastName(string lastname)
        {
            var bossExist = _context.Bosses.Any(x=>x.LastName==lastname);
            return bossExist;
        }
    }
}
