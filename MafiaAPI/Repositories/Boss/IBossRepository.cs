using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository
    {
<<<<<<< HEAD:MafiaAPI/Repositories/Boss/IBossRepository.cs
=======
        public void Post(Boss boss);
        public Boss GetById(int id);
        public Boss GetByFirstAndLastname(string firstname, string lastname);
        public Boss GetByName(string name);
        public void Update(Boss newBoss);
        public void Delete(int id);
>>>>>>> 06069cfbb38b554f986aabdb55117282a8ba84b1:MafiaAPI/Repositories/IBossRepository.cs
        public bool IsBossWithThatLastName(string lastname);
    }
}
