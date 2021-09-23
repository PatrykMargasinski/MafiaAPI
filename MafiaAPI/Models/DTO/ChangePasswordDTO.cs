namespace MafiaAPI.Models
{
    public class ChangePasswordDTO
    {
        public long PlayerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
