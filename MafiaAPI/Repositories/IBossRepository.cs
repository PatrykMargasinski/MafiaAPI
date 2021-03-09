using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository
    {
        public Boss Get();
        public void Update(Boss newBoss);
    }
}
