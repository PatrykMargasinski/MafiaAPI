using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{
    public interface IBossRepository : ICrudRepository<Boss>
    {
        public Boss GetByFirstAndLastname(string firstname, string lastname);
        public Boss GetByFullname(string name);
        public bool IsBossWithThatLastName(string lastname);
        public IList<string> GetSimilarNames(string name);
    }
}
