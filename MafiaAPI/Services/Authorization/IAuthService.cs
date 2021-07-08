using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Services
{
    public interface IAuthService
    {
        public string[] LoginValidation(LoginDto user);
        public string CreateToken();
        public string[] RegisterValidation(RegisterDTO user);
        public void CreateUser(RegisterDTO user);
        public string[] DeleteAccount(long playerId);
    }
}
