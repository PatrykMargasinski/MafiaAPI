using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MafiaDBContext _context;

        public PlayerRepository(MafiaDBContext context)
        {
            _context = context;
        }

        public Player Get(int id)
        {
            return _context.Players.FirstOrDefault(player => player.PlayerId == id);
        }

        public Player GetByNick(string nick)
        {
            return _context.Players.FirstOrDefault(player => player.Nick == nick);
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public void Post(Player player)
        {
            if(player!=null)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
            }
        }

        public void Update(Player newPlayer)
        {
            var updatingPlayer = _context.Players.FirstOrDefault(player => player.PlayerId == newPlayer.PlayerId);
            if (newPlayer!=null && updatingPlayer!=null)
            {
                updatingPlayer.BossId = newPlayer.BossId;
                updatingPlayer.Boss = newPlayer.Boss;
                updatingPlayer.Nick = newPlayer.Nick;
                updatingPlayer.Password = newPlayer.Password;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var deletingPlayer = _context.Players.FirstOrDefault(player => player.PlayerId == id);
            _context.Players.Remove(deletingPlayer);
            _context.SaveChanges();
        }

        public bool IsPlayerWithThatNick(string nick)
        {
            var playerExist = _context.Players.Any(x=>x.Nick==nick);
            return playerExist;
        }
    }
}
