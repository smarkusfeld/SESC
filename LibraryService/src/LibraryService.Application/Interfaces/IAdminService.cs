using LibraryService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for admin services.
    /// </summary>
    public interface IAdminService
    {
        /// <summary>
        /// Method to view all books in the library
        /// </summary>
        Task<IEnumerable<BookDTO>> GetAllBooks();

        /// <summary>
        /// Method to add new books to the database using the barcode scanner
        /// </summary>
        Task<bool> AddBook(string isbn);

        /// <summary>
        /// Method to display all students and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllStudentAccounts();

        /// <summary>
        /// Method to display all current loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllCurrentLoans();

        /// <summary>
        /// Method to display all overdue loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllOverdueLoans();

    }
}
