using FinanceMicroservice.Core.Infastructure;
using FinanceMicroservice.Core.Interfaces;

namespace FinanceMicroservice.Infastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public IAccountRepository Accounts { get; }
        public IInvoiceRepository Invoices { get; }
        public UnitOfWork(DataContext dbContext, IAccountRepository accountRepository, IInvoiceRepository invoiceRepository)
        {
            _dbContext = dbContext;
            Accounts = accountRepository;
            Invoices = invoiceRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}