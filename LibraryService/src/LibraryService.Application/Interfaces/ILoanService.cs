using LibraryService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for loan services.
    /// </summary>
    public interface ILoanService
    {
        

       

        /// <summary>
        /// Method to display all current loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllCurrentLoans();

        /// <summary>
        /// Method to display all overdue loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllOverdueLoans();

        /// <summary>
        /// Method to view loan history
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetLoanHistory(int accountID);

    }
}
