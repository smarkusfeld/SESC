using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces.Repositories
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetAllOverdueAsync();
        Task<IEnumerable<Loan>> GetAllActiveAsync();
    }
}
