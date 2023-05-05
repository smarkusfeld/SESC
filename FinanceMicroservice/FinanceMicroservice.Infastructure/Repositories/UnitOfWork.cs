using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Application.Repositories;
using FinanceMicroservice.Infastructure.Context;
using FinanceMicroservice.Infastructure.Repositories;

namespace FinanceMicroservice.Application.Services
{
    ///<summary>
    /// This class includes the properties and methods needsed to carry out any transactions or data operations 
    ///</summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private IAccountRepository _accounts;
        private IInvoiceRepository _invoices;
        private IPaymentRepository _payments;
        public IAccountRepository Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new AccountRepository(_dbContext);
                }
                return _accounts;
            }   
        }
        public IInvoiceRepository Invoices
        {
            get
            {
                if (_invoices == null)
                {
                    _invoices = new InvoiceRepository(_dbContext);
                }
                return _invoices;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentRepository(_dbContext);
                }
                return _payments;
            }
        }
        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _accounts = Accounts;
            _invoices = Invoices;
            _payments = Payments;
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