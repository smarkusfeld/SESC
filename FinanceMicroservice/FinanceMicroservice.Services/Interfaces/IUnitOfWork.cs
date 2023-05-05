using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application
{
    ///<summary>
    /// This interface defines a contract for the unit of work class
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IPaymentRepository Payments { get; }
        IInvoiceRepository Invoices { get; }
        int Save();
        
    }
}
