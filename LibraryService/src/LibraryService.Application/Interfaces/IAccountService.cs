using LibraryService.Application.Models;

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
       // Task<bool>Login();

        /// <summary>
        /// Method for admin login
        /// </summary>

        /// <summary>
        /// Method to display all students and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllStudentAccounts();

        /// <summary>
        /// Method to display all current loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllCurrentLoans();

        /// <summary>
        /// Method to display all overdue loans
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAllOverdueLoans();

        /// <summary>
        /// Method to view loan history
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetLoanHistory(int accountID);

        /// <summary>
        /// Method to create new loan
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<LoanDTO> CreateLoan(string studentID, string ISBN, int pin);

        /// <summary>
        /// Method to create new reservation
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<ReservationDTO> CreateReservation(string studentID, string ISBN, int pin);

        /// <summary>
        /// Method to return book
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="ISBN"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        Task<LoanDTO> ReturnBook(string studentID, string ISBN, int pin);

        /// <summary>
        /// Method to issue fine
        /// </summary>
        /// <param name="loanDTO"></param>
        /// <returns></returns>
        Task<bool> IssueFine(LoanDTO loanDTO);

        /// <summary>
        /// Method to get available copy a book
        /// </summary>
        Task<BookCopyDTO> GetAvailableBookCopy(string isbn);

    }
}
