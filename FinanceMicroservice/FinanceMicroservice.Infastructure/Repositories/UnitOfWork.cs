using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Infastructure.Context;

namespace FinanceMicroservice.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public IAccountRepository Accounts { get; }
        public IInvoiceRepository Invoices { get; }
        public IPaymentRepository Payments { get; }
        public UnitOfWork(DataContext dbContext, IAccountRepository accountRepository, IInvoiceRepository invoiceRepository, IPaymentRepository paymentRepository)
        {
            _dbContext = dbContext;
            Accounts = accountRepository;
            Invoices = invoiceRepository;
            Payments = paymentRepository;
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