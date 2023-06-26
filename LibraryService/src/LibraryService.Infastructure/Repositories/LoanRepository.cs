using LibraryService.Application.Interfaces;
using LibraryService.Domain.Common.Enums;
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
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(DataContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IEnumerable<Loan>> GetAllActiveAsync() => await GetAllWhereAsync(x => x.IsComplete == false);
        public async Task<IEnumerable<Loan>> GetAllOverdueAsync() => await GetAllWhereAsync(x => x.Status == LoanStatus.Overdue);
    }
}
