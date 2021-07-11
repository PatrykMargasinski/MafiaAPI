using System.ComponentModel.DataAnnotations;

namespace MafiaAPI.Models.Requests
{
    public class MissionStartRequest
    {
        [Required]
        public long MissionId;
        [Required]
        public long AgentId;
    }
}
