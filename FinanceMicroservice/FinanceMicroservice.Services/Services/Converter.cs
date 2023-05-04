using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Services
{
    public class Converter<T1, T2> : IConverter<T1, T2>
    {
    
        public Account Convert(AccountDTO dto)
        {
            return new Account
            {
                ID = dto.ID,
                StudentID = dto.StudentID,
                HasOutstandingBalance = dto.HasOutstandingBalance,

            };
        }
        public AccountDTO Convert(Account entity)
        {
            return new AccountDTO
            {
                ID = entity.ID,
                StudentID = entity.StudentID,
                HasOutstandingBalance = entity.HasOutstandingBalance,

            };
        }
        public Invoice Convert(InvoiceDTO dto)
        {
            return new Invoice
            {
                ID = dto.ID,
                //add other fields 

            };
        }
        public InvoiceDTO Convert(Invoice entity)
        {
            return new InvoiceDTO
            {
                ID = entity.ID,
                //add other fields 

            };
        }
        public Payment Convert(PaymentDTO dto)
        {
            return new Payment
            {
                ID = dto.ID,
                //add other fields 

            };
        }
        public PaymentDTO Convert(Payment entity)
        {
            return new PaymentDTO
            {
                ID = entity.ID,
                //add other fields 

            };
        }


        public T2 Convert(T1 source_object)
        {
            throw new NotImplementedException();
        }
    }
   
}
