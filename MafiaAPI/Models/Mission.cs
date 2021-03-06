using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public int DifficultyLevel { get; set; }
        public int Loot { get; set; }
    }
}
