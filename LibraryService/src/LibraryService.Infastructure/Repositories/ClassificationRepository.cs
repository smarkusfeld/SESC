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
    public class ClassificationRepository : GenericRepository<ClassificationModel>, IClassificationRepository
    {
        public ClassificationRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<ClassificationModel> GetAsync(int id) => await _context.Set<ClassificationModel>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
