using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public partial class MissionType : Model
    {
        public MissionType()
        {
        }
        public string Name { get; set; }
        public int MinDifficulty { get; set; }
        public int MaxDifficulty { get; set; }
        public int MinLoot { get; set; }
        public int MaxLoot { get; set; }
        public int StrengthPercentage { get; set; }
        public int DexterityPercentage { get; set; }
        public int IntelligencePercentage { get; set; }
        public double Duration { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
