using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly AccountService _accountservice;
        private readonly InvoiceService _invoiceservice;
        private readonly PaymentService _paymentservice;

        public FinanaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountservice = new AccountService();
            _invoiceservice = new InvoiceService();
            _paymentservice = new PaymentService();
        }


       
    }
}
