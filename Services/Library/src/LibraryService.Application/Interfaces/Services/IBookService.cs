using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for book and isbn services
    /// </summary>
    public interface IBookService  
    {

        /// <summary>
        /// Get book details using the isbn api
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        Task<NewBookRecordDTO> GetBookDetails(string isbn);

        /// <summary>
        /// Add new books to the database using the barcode scanner
        /// </summary>
        Task<BookDTO> AddBookByISBN(string isbn);


        /// <summary>
        /// Add book copy to exisiting book record
        /// </summary>
        /// <param name="bookRecord"></param>
        /// <returns></returns>
        Task<BookDTO> AddBookCopy(Book bookRecord);

        /// <summary>
        /// Create new book record
        /// </summary>
        /// <param name="newBookRecord"></param>
        /// <returns></returns>
        Task<BookDTO> CreateNewBookRecord(NewBookRecordDTO newBookRecord);

    }
}
