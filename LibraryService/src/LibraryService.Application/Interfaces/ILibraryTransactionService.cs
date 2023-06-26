using LibraryService.Application.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// Interface for loan related services
    /// </summary>
    public interface ILibraryTransactionService
    {
        /// <summary>
        /// Method to create new loan
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<LoanDTO> CreateLoan(string id, string ISBN, int pin, int duration);

        /// <summary>
        /// Method to create new reservation
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<ReservationDTO> CreateReservation(string id, string ISBN, int pin);


        /// <summary>
        /// Method to return book
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<LoanDTO> ReturnBook(string id, string ISBN, int pin);

        /// <summary>
        /// Method to renew book
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<LoanDTO> RenewBook(string id, string ISBN, int pin);

        /// <summary>
        /// Method to get all active loans
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LoanDTO>> GetAllOverdueLoans();

        /// <summary>
        /// Method to get all overdue loans
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LoanDTO>> GetAllActiveLoans();
    }
}
