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
        Task<bool> AddBook(string isbn);

        /// <summary>
        /// Method to borrow a book using isbn barcode
        /// </summary>
        Task<LoanDTO> CreateNewLoan(string isbn);

        /// <summary>
        /// Method to borrow return book using isbn barcode
        /// </summary>
        Task<LoanDTO> ReturnBook(string isbn);
        


        
    }
}
