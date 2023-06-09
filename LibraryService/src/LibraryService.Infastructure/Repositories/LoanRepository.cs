using LibraryService.Application.Interfaces;
using LibraryService.Domain.Models;
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
    public class LoanRepository : GenericRepository<LoanModel>, ILoanRepository
    {
        public LoanRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<LoanModel> GetAsync(int id) => await _context.Set<LoanModel>().AsNoTracking().SingleOrDefaultAsync(T => T.Id.Equals(id));
    }
}
