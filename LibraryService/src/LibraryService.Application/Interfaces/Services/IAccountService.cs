using LibraryService.Application.Models;

namespace LibraryService.Application.Interfaces.Services
{
    /// <summary>
    /// This interface defines a contract for account services.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Method to create new student account
        /// </summary>
        Task<AccountDTO> CreateStudentAccount(string Id);

        /// <summary>
        /// Method to create new student account
        /// </summary>
        Task<AccountDTO> CreateAccount(string Id, string type);

        /// <summary>
        /// ChangePin
        /// </summary>
        Task<bool> UpdateAccountPin(string id, string oldPin, string newPin);


        /// <summary>
        /// Method to display all accounts and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllAccounts();

        /// <summary>
        /// Method to display all accounts and the number of books on loan/overdue
        /// </summary>
        Task<IEnumerable<AccountDTO>> GetAllAccountsByType(string type);

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
        Task<IEnumerable<LoanDTO>> GetLoanHistory(string accountID);

        /// <summary>
        /// Method to view loan history
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAccountActiveLoans(string accountID);

        /// <summary>
        /// Method to view loan history
        /// </summary>
        Task<IEnumerable<LoanDTO>> GetAccountOverdueLoans(string accountID);

    }
}
