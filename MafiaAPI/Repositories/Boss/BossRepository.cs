using MafiaAPI.Database;
using MafiaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class BossRepository : CrudRepository<Boss>, IBossRepository
    {

        public BossRepository(MafiaDBContext context) : base(context) { }

        public Boss GetByFirstAndLastname(string firstname, string lastname)
        {
            var boss = _context.Bosses.FirstOrDefault(boss => boss.FirstName == firstname && boss.LastName == lastname);
            return boss;
        }
        public Boss GetByFullname(string name)
        {
            name = name.Replace(" ", "");
            var boss = _context.Bosses.FirstOrDefault(boss => boss.FirstName + boss.LastName == name || boss.LastName + boss.FirstName == name);
            return boss;
        }

        public bool IsBossWithThatLastName(string lastname)
        {
            var bossExist = _context.Bosses.Any(x => x.LastName == lastname);
            return bossExist;
        }

        public IList<string> GetSimilarNames(string name)
        {
            var names = _context.Bosses
                .Where(x =>
                (x.LastName.ToLower() + x.FirstName.ToLower()).StartsWith(name)
                || (x.FirstName.ToLower() + x.LastName.ToLower()).StartsWith(name))
                .Select(x => x.FirstName + " " + x.LastName)
                .Take(5)
                .ToList();
            return names;
        }
    }
}
