using System.Linq.Expressions;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application.Services
{
    public class InvoiceService : IFinanceService<InvoiceDTO>
    {
        public Task Add(InvoiceDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task Pay(string id, PaymentDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(InvoiceDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDTO> Find(Expression<Func<InvoiceDTO, bool>> expression)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<InvoiceDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(InvoiceDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
