using LibraryService.Application.DTOs;
using LibraryService.Application.Models;
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
        /// Method to create new student account
        /// </summary>
        Task<bool> CreateAccount(string studentID);
        /// <summary>
        /// Method to register User
        /// </summary>
        Task<bool> RegisterUser(string studentID);
        

        /// <summary>
        /// Method for user login
        /// </summary>
        Task<bool>Login(UserLoginModel userLoginModel);

        /// <summary>
        /// Method for admin login
        /// </summary>

        /// <summary>
        /// Method to display all students and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllStudentAccounts();

        /// <summary>
        /// Validate Account
        /// </summary>
        bool ValidateAccount(StudentRegistrationModel model);

    }
}
