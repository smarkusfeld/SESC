using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces.Repositories
{
    /// <summary>
    /// Repository Interface for the book entity
    /// </summary>
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> AddCopyAsync(Book book);
        Task<bool> UpdateCopiesAsync(Book book);
    }
}
