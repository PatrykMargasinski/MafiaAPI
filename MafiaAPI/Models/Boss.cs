using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Boss : Model
    {
        public Boss()
        {
            Agents = new HashSet<Agent>();
            Messages = new HashSet<Message>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Money { get; set; }
        public DateTime? LastSeen { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
