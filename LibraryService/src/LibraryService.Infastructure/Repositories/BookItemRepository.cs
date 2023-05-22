﻿using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class BookItemRepository : GenericRepository<BookItem>, IBookItemRepository
    {
        public BookItemRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
