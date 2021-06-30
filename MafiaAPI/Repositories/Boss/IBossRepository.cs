using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository
    {
        public bool IsBossWithThatLastName(string lastname);
    }
}
