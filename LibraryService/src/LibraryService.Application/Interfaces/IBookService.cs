using LibraryService.Application.DTOs;
using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for book services.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Method to view all books in the library
        /// </summary>
        Task<IEnumerable<BookDTO>> GetAllBooks();

        /// <summary>
        /// Method to add new books to the database using the barcode scanner
        /// </summary>
        Task<bool> AddBook(string isbn, OpenLibraryRecord bookdetail);

        /// <summary>
        /// Method to borrow a book using isbn barcode
        /// </summary>
        Task<bool> CreateNewLoan(int accountid, int bookitemid);

        /// <summary>
        /// Method to borrow return book using isbn barcode
        /// </summary>
        Task<bool> ReturnLoan(LoanDTO dto);

        /// <summary>
        /// Method to check available copies of a book
        /// </summary>
        Task<BookCopyDTO> GetAvailableBookCopy(string isbn);

        ///<summary>
        ///Method to get library account id
        /// </summary>
        Task<AccountDTO> GetLibraryAccount(string studentid);

        /// <summary>
        /// Method to check available copies of a book
        /// </summary>
        Task<int> CheckBookCount(string isbn);

        /// <summary>
        /// Method to get existing loan using isbn barcode
        /// </summary>
        Task<LoanDTO> FindLoan(string studentid, string isbn);

        Task<bool> ISBNCheck(string isbn);

        Task<OpenLibraryRecord> GetDetails(string isbn);

    }
}
