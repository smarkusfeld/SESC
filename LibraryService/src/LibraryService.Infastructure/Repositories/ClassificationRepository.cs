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
    public class ClassificationRepository : GenericRepository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<Classification> GetAsync(int id) => await _context.Set<Classification>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
