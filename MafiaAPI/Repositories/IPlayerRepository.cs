using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPlayerRepository
    {
        public Player Get(int id);
        public Player GetByNick(string nick);
        public Player GetWithBoss(int id);
        public IEnumerable<Player> GetAll();
        public void Post(Player player);
        public void Update(Player newPlayer);
        public void Delete(int id);
        public bool IsPlayerWithThatNick(string nick);
    }
}
