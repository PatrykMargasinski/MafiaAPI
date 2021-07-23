using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository : ICrudRepository<Message>
    {
        public IList<Message> GetAllMessagesTo(long bossId, int fromRange, int toRange, string bossNameFilter, bool onlyUnseen);
        public int CountMessagesTo(long bossId);
    }
}
