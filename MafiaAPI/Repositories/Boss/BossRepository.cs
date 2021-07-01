using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class BossRepository : CrudRepository<Boss> ,IBossRepository
    {
    
        public BossRepository(MafiaDBContext context): base(context){}

        public Boss GetByFirstAndLastname(string firstname, string lastname)
        {
            var boss = _context.Bosses.FirstOrDefault(boss => boss.FirstName==firstname && boss.LastName==lastname);
            return boss;
        }
        public Boss GetByName(string name)
        {
            var boss = _context.Bosses.FirstOrDefault(boss => boss.FirstName==name);
            return boss;
        }

        public bool IsBossWithThatLastName(string lastname)
        {
            var bossExist = _context.Bosses.Any(x=>x.LastName==lastname);
            return bossExist;
        }
    }
}
