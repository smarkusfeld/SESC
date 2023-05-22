using LibraryService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// This interface defines a contract for authentication services.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Method to register new student account
        /// </summary>
        Task<string> Register(AccountDTO AccountDTO);
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
    }
}
