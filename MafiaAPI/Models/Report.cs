using System;

namespace MafiaAPI.Models
{
    public class Report : Model
    {
        public long? ToBossId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime ReceivedDate { get; set; }
        public bool Seen { get; set; }
        public virtual Boss ToBoss { get; set; }
    }
}
