using FinanceMicroservice.Application.DTOs;

namespace FinanceMicroservice.Application.Interfaces
{
    ///<summary>
    /// This interface defines a contract for account services
    ///</summary>
    public interface IAccountService
    {
        /// <summary>
        /// This method creates a new account
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> CreateAccount(AccountDTO accountDTO);

        /// <summary>
        /// This method returns all accounts  
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<IEnumerable<AccountDTO>> GetAllAccounts();


        /// <summary>
        /// This method returns an account from the account id
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the accountDTO
        /// </returns>
        Task<AccountDTO> GetAccountById(int accountID);
        /// <summary>
        /// This method returns an account from the student id
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the accountDTO
        /// </returns>
        Task<AccountDTO> GetStudentAccount(string studentID);
        /// <summary>
        /// Method to update an account
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> UpdateAccount(AccountDTO accountDTO);
        /// <summary>
        /// Method to delete an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> DeleteAccount(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result the blance for the account
        /// </returns>
        Task<decimal> GetAccountBalance(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> CheckOutstanding(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetAllInvoices(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(int accountID);

    }
}
