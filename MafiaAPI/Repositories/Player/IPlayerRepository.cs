using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IPlayerRepository
    {
        public Player GetByNick(string nick);
        public bool IsPlayerWithThatNick(string nick);
    }
}
