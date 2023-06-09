using LibraryService.Application.Interfaces;
using LibraryService.Domain.Models;
using LibraryService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class PublisherRepository : GenericRepository<PublisherModel>, IPublisherRepository
    {
        public PublisherRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<PublisherModel> GetAsync(int id) => await _context.Set<PublisherModel>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
