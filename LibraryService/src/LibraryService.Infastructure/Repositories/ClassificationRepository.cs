﻿using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class ClassificationRepository : GenericRepository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
