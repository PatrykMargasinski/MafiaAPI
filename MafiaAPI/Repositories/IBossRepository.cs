using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository
    {
        public void Post(Boss boss);
        public Boss GetById(int id);
        public Boss GetByFirstAndLastname(string firstname, string lastname);
        public void Update(Boss newBoss);
        public void Delete(int id);
        public bool IsBossWithThatLastName(string lastname);
    }
}
