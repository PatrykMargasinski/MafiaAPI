namespace MafiaAPI.Models
{
    public class AgentForSale : Model
    {
        public long AgentId { get; set; }
        public long Price { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
