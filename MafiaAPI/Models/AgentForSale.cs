using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public class AgentForSale  : Model
    {
        public long AgentId { get; set; }
        public long Price { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
