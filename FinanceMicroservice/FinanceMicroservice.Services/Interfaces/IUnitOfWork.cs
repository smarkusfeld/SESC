using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IPaymentRepository Payments { get; }
        IInvoiceRepository Invoices { get; }
        int Save();
        Task<int> CommitAsync();
    }
}
