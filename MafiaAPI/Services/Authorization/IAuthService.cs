using MafiaAPI.Models;

namespace MafiaAPI.Services
{
    public interface IAuthService
    {
        public string[] LoginValidation(LoginDto user);
        public string CreateToken(string user);
        public string[] RegisterValidation(RegisterDTO user);
        public void CreateUser(RegisterDTO user);
        public string[] DeleteAccount(long playerId);
        public bool VerifyPassword(Player player, string pass);
        public string[] ChangePassword(ChangePasswordDTO changeModel);
    }
}
