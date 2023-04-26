using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Infastructure.Context;


namespace FinanceMicroservice.Application.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
