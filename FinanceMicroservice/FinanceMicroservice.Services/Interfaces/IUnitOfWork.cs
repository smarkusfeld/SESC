using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IInvoiceRepository Invoices { get; }
        int Save();
    }
}
