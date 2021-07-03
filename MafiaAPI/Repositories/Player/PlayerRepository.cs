using MafiaAPI.Models;
using MafiaAPI.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Repositories
{
    
    public class PlayerRepository :CrudRepository<Player>, IPlayerRepository
    {
    
        public PlayerRepository(MafiaDBContext context): base(context){}
        
        public Player GetByNick(string nick)
        {
            return _context.Players.FirstOrDefault(player => player.Nick == nick);
        }

        public Player GetWithBoss(int id)
        {
            return _context.Players.Include(x=>x.Boss).FirstOrDefault(player => player.Id == id);
        }

        public bool IsPlayerWithThatNick(string nick)
        {
            var playerExist = _context.Players.Any(x=>x.Nick==nick);
            return playerExist;
        }
    }
}
