using MafiaAPI.Database;
using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public class FirstNameRepository : CrudRepository<FirstName>, IFirstNameRepository
    {
        public FirstNameRepository(MafiaDBContext context) : base(context) { }
    }
}
