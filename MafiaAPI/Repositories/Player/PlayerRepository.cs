using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class PlayerRepository :CrudRepository<Player>, IPlayerRepository
    {
    
        public PlayerRepository(MafiaDBContext context): base(context){}
        
        public Player GetByNick(string nick)
        {
            return _context.Players.FirstOrDefault(player => player.Nick == nick);
        }

        public bool IsPlayerWithThatNick(string nick)
        {
            var playerExist = _context.Players.Any(x=>x.Nick==nick);
            return playerExist;
        }
    }
}
