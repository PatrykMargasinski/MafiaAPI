using System;
using MafiaAPI.Service;

namespace MafiaAPI.Models
{
    public class AgentForSaleDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public long Price { get; set; }
    }
}
