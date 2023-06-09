﻿using LibraryService.Application.Interfaces;
using LibraryService.Domain.BookAggregate;
using LibraryService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class BookClassificationRepository : GenericRepository<BookClassification>, IBookClassificationRepository
    {
        public BookClassificationRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
