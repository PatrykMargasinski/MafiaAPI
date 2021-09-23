using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository : ICrudRepository<Message>
    {
        public IList<Message> GetAllMessagesTo(long bossId, int fromRange, int toRange, string bossNameFilter, bool onlyUnseen);
        public int CountMessagesTo(long bossId);
    }
}
