using FinanceMicroservice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDTO> GetInvoiceById(int id);
        Task<InvoiceDTO> GetInvoiceAccountById(int id);
        Task<ICollection<AccountDTO>> GetAll();
    }
}
