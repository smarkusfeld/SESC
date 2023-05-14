using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using FinanceService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Infastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
