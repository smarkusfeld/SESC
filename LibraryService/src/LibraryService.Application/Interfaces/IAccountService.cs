using LibraryService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for account services.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Method to register new student account
        /// </summary>
        Task<string> Register(string studentID);
        /// <summary>
        /// Method to register new admin account
        /// </summary>

        /// <summary>
        /// Method for student login
        /// </summary>
        /// 

        /// <summary>
        /// Method for admin login
        /// </summary>
        
        /// <summary>
        /// Method to display all students and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllStudentAccounts();

    }
}
