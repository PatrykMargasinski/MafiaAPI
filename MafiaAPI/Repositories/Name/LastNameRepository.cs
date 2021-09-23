using MafiaAPI.Database;
using MafiaAPI.Models;

namespace MafiaAPI.Repositories
{
    public class LastNameRepository : CrudRepository<LastName>, ILastNameRepository
    {
        public LastNameRepository(MafiaDBContext context) : base(context) { }
    }
}
