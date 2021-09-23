using MafiaAPI.Models;

namespace MafiaAPI.Services.Messages
{
    public interface IMessageService
    {
        public void SendMessage(Message message);
        public void SendMessage(string fromBossName, string toBossName, string content);
    }
}
