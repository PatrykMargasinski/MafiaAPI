using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository: ICrudRepository<Boss>
    {
        public Boss GetByFirstAndLastname(string firstname, string lastname);
        public Boss GetByName(string name);
        public bool IsBossWithThatLastName(string lastname);
    }
}
