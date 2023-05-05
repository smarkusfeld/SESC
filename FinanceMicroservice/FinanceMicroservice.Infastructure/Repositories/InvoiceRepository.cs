using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Infastructure.Context;


namespace FinanceMicroservice.Application.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
