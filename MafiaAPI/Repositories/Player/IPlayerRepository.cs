using MafiaAPI.Models;

namespace MafiaAPI.Repositories
{
    public interface IPlayerRepository : ICrudRepository<Player>
    {
        public Player GetByNick(string nick);
        public Player GetWithBoss(long id);
        public bool IsPlayerWithThatNick(string nick);
    }
}
