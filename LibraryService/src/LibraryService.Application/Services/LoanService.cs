using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class LoanService : ILoanService
    {
        public Task<IEnumerable<LoanDTO>> GetAllCurrentLoans()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoanDTO>> GetAllOverdueLoans()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoanDTO>> GetLoanHistory(int accountID)
        {
            throw new NotImplementedException();
        }
    }
}
