using MafiaAPI.Database;
using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public class LastNameRepository : CrudRepository<LastName>, ILastNameRepository
    {
        public LastNameRepository(MafiaDBContext context) : base(context) { }
    }
}
