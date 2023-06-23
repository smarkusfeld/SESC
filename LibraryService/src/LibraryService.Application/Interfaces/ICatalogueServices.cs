using LibraryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for library catalogue services
    /// </summary>
    public interface ICatalogueServices
    {
        /// <summary>
        /// Method to view all books in the library catalogue
        /// </summary>
        Task<IEnumerable<BookDTO>> GetAllBooks();

        /// <summary>
        /// Method to view all authors in the library catalogue
        /// </summary>
        Task<IEnumerable<AuthorDTO>> GetAllAuthors();

        /// <summary>
        /// Method to view all publishers in the library catalogue
        /// </summary>
        Task<IEnumerable<PublisherDTO>> GetAllPublishers();

        /// <summary>
        /// Method to view all subject in the library catalogue
        /// </summary>
        Task<IEnumerable<SubjectDTO>> GetAllSubjects();

        /// <summary>
        /// Method to add new books to the database using the barcode scanner
        /// </summary>
        Task<bool> AddBook(string isbn, OpenLibraryRecord bookdetail);

        /// <summary>
        /// Method to get a book using the barcode scanner
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        Task<BookDTO> GetBook(string isbn);

        Task<OpenLibraryRecord> GetDetails(string isbn);

        /// <summary>
        /// Method to update book
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BookDTO> UpdateBook(BookDTO dto);

        /// <summary>
        /// Method to Update Author
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AuthorDTO> UpdateAuthor(AuthorDTO dto);

        /// <summary>
        /// Method to Update Subject
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<SubjectDTO> UpdateSubject(SubjectDTO dto);

        /// <summary>
        /// Method to Update Publisher
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<PublisherDTO> UpdatePublisher(PublisherDTO dto);

    }
}
