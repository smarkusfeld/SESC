using FinanceMicroservice.Core.Models;
using FinanceMicroservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Services
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
