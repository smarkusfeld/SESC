using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.RepositoryInterfaces
{
    /// <summary>
    /// Repository Interface for the book entity
    /// </summary>
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetAsync(string ISBN);

        Task<bool> AddBookAuthor(Author author);

        Task<bool> AddBookSubject(Subject subject);

        Task<bool> AddBookPublisher(Publisher publisher);

        Task<bool> AddBookCopy(Book copy);

    }
}
