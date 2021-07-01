using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPlayerRepository: ICrudRepository<Player> 
    {
        public Player GetByNick(string nick);
<<<<<<< HEAD:MafiaAPI/Repositories/Player/IPlayerRepository.cs
=======
        public Player GetWithBoss(int id);
        public IEnumerable<Player> GetAll();
        public void Post(Player player);
        public void Update(Player newPlayer);
        public void Delete(int id);
>>>>>>> main:MafiaAPI/Repositories/IPlayerRepository.cs
        public bool IsPlayerWithThatNick(string nick);
    }
}
