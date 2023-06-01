using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<Author> GetAsync(int id) => await _context.Set<Author>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
