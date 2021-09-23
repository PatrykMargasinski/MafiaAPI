using MafiaAPI.Database;
using MafiaAPI.Models;

namespace MafiaAPI.Repositories
{
    public class FirstNameRepository : CrudRepository<FirstName>, IFirstNameRepository
    {
        public FirstNameRepository(MafiaDBContext context) : base(context) { }
    }
}
