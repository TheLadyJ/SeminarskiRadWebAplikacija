﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRadnikRepository : IRepository<Radnik>
    {
        Radnik SearchByUsernamePassword(string username, string password);
    }
}
