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
            MessageFromBosses = new HashSet<Message>();
            MessageToBosses = new HashSet<Message>();
            ReportToBosses = new HashSet<Report>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long Money { get; set; }
        public DateTime? LastSeen { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Message> MessageFromBosses { get; set; }
        public virtual ICollection<Message> MessageToBosses { get; set; }
        public virtual ICollection<Report> ReportToBosses { get; set; }

        public void AddMoney(int money) 
        {
            this.Money += money;
        }

        public void SpendMoney(int money)
        {
            if(this.Money < money) {
                throw new InvalidOperationException("Logfile cannot be read-only");
            }
            this.Money -= money;
        }
    }
}
