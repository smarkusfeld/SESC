﻿using Microsoft.EntityFrameworkCore;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class ProgrammeRepository : GenericRepository<Programme>, IProgrammeRepository
    {
        public ProgrammeRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Programme?> GetAsync(object key)
        {
            return await _set.SingleOrDefaultAsync(x => x.ProgrammeCode.Equals(key));
        }
    }
}
