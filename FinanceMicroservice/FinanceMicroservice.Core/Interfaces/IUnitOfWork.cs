using FinanceMicroservice.Core.Interfaces;

namespace FinanceMicroservice.Core.Infastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IInvoiceRepository Invoices { get; }
        int Save();
    }
}
