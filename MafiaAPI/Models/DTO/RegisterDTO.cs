namespace MafiaAPI.Models
{
    public class RegisterDTO
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public string BossFirstName { get; set; }
        public string BossLastName { get; set; }
        public string[] AgentNames { get; set; }
    }
}
