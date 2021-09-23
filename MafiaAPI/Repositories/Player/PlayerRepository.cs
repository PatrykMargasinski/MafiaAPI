using MafiaAPI.Database;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class PlayerRepository : CrudRepository<Player>, IPlayerRepository
    {

        public PlayerRepository(MafiaDBContext context) : base(context) { }

        public Player GetByNick(string nick)
        {
            return _context.Players.FirstOrDefault(player => player.Nick == nick);
        }

        public Player GetWithBoss(long id)
        {
            return _context.Players.Include(x => x.Boss).FirstOrDefault(player => player.Id == id);
        }

        public bool IsPlayerWithThatNick(string nick)
        {
            var playerExist = _context.Players.Any(x => x.Nick == nick);
            return playerExist;
        }
    }
}
