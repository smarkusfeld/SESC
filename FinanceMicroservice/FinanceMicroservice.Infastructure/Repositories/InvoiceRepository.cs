using FinanceMicroservice.Core.Interfaces;
using FinanceMicroservice.Core.Models;
using FinanceMicroservice.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Infastructure.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
