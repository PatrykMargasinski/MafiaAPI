using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Services
{
    public interface ISecurityService
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
        public string Hash(string text);
    }
}
