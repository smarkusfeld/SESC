﻿using FinanceService.Application.Interfaces;
using FinanceService.Infastructure.Context;
using FinanceService.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Infastructure
{ 
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

        /// <summary>
        /// Completes the unit of work, saving all repository changes to the underlying data-store.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public int Save() =>_dbContext.SaveChanges();
      



        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <returns><see cref="ValueTask"/></returns>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing"></param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}