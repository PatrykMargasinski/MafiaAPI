using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository : ICrudRepository<Message>
    {
        public IList<Message> GetAllMessagesTo(long bossId);
        public IList<Message> GetAllMessagesFrom(long bossId);
        public IList<Message> GetAllMessagesToRange(long bossId, int fromRange, int toRange, string bossNameFilter, bool onlyUnseen);
        public IList<Message> GetAllMessagesFromRange(long bossId, int fromRange, int toRange);
        public int GetMessageToCount(long bossId);
        public string GetMessageContent(long messageId);
    }
}
