﻿using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IMissionRepository: ICrudRepository<Mission>
    {
        public IEnumerable<Mission> GetAvailableMissions();
    
    }
}