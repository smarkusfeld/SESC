using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Services
{
    public class FinanaceService
    {
        //add model validation?
        private readonly IUnitOfWork _unitOfWork;
  
        public FinanaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //check records 
        public async Task<bool> hasAccount(string studentID)
        {
             var result = await _unitOfWork.Accounts.FindAsync(x => x.StudentID == studentID);

            if (result == null)
            {
                return false;
            }
            return true;
        }
        public bool IsAccount(int id) => _unitOfWork.Accounts.Exists(id);
        public bool IsInvoice(int id) => _unitOfWork.Invoices.Exists(id);
        public bool IsPayment(int id) => _unitOfWork.Payments.Exists(id);

        //convert to DTO
        private static AccountDTO AccountDTO(Account account)
        {
            return new AccountDTO
            {
                ID = account.ID,
                StudentID = account.StudentID,
                HasOutstandingBalance = account.HasOutstandingBalance,

            };
        }

        private static InvoiceDTO InvoiceDTO(Invoice invoice)
        {
            return new InvoiceDTO
            {
                ID = invoice.ID,
                //add other fields 

            };
        }
        private static PaymentDTO PaymentDTO(Payment payment)
        {
            return new PaymentDTO
            {
                ID = payment.ID,
                //add other fields 

            };
        }
    




        public bool MakePayment(int invoiceID, PaymentDTO paymentDTO)
        {
            if (_unitOfWork.Invoices.Exists(invoiceID))
            {
                var invoice = _unitOfWork.Invoices.FindByID(invoiceID);
                var payment = new Payment
                {
                    //add
                    PaymentDate = paymentDTO.PaymentDate,
                    Amount = paymentDTO.Amount,
                    Invoice = invoice,
                    Account = invoice.Account,
                };
                _unitOfWork.Payments.Create(payment);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

    }
}
