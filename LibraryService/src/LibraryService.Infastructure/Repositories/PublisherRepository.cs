using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<Publisher> GetAsync(int id) => await _context.Set<Publisher>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
