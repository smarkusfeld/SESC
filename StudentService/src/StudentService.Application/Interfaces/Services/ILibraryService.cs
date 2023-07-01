using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Services
{
    public interface ILibraryService
    {
        /// <summary>
        /// Create Library Account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>true, if student is eligibile to graduate, false if not</returns>
        Task<bool> CreateLibraryAccount(string studentId);
    }
}
