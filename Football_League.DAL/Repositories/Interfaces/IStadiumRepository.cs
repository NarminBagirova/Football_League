﻿using Football_League.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface IStadiumRepository : IGenericRepository<Stadium>
    {
        Task<Stadium> GetByIdAsync(int id);
    }
}
