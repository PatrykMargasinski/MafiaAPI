using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public class ChangePasswordDTO
    {
        public long PlayerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
