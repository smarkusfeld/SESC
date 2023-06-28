using LibraryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for openlibrary service
    /// </summary>
    public interface IISBNService : IDisposable
    {
        /// <summary>
        /// Get book details using the open library api
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        Task<NewBookRecordDTO> GetBookDetails(string isbn);


    }
}
