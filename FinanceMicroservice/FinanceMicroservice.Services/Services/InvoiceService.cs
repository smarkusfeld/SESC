using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Services
{
     public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CancelPayment(PaymentDTO paymentDTO)
        {
            var check = await _unitOfWork.Payments.Find(paymentDTO.ID);
            if (check != null)
            {
                var payment = _mapper.Map<Payment>(paymentDTO);
                _unitOfWork.Payments.Update(payment);
                var result = _unitOfWork.Save();

                if (result > 0)               
                    return true;               
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> CreateInvoice(InvoiceDTO invoiceDTO)
        {
            // Validation logic
            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            if (invoice != null)
            {
                await _unitOfWork.Invoices.Create(invoice);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInvoice(int invoiceID)
        {
            var invoice = await _unitOfWork.Invoices.Find(invoiceID);
            if (invoice != null)
            {
                _unitOfWork.Invoices.Delete(invoice);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAll();
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllOutstandingInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.Status == InvoiceStatus.Outstanding.Name);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }
        public async Task<IEnumerable<InvoiceDTO>> GetAllOverdueInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.DueDate < DateTime.Now);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }
        public Task<InvoiceDTO> GetInvoiceById(int invoiceID)
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceDTO> GetInvoiceByReference(string reference)
        {
            var invoiceDTO = await _unitOfWork.Invoices.FindWhere(x => x.Reference == reference);
            return _mapper.Map<InvoiceDTO>(invoiceDTO);
        }

        public async Task<bool> MakePayment(PaymentDTO paymentDTO)
        {
            var check = await _unitOfWork.Invoices.Find(paymentDTO.InvoiceID);
            if (check != null)
            {
                var payment = _mapper.Map<Payment>(paymentDTO);
                await _unitOfWork.Payments.Create(payment);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;

        }

        public async Task<IEnumerable<PaymentDTO>> PaymentsToBeProcessed()
        {
            var paymentList = await _unitOfWork.Payments.FindAllWhere(x => x.Status == PaymentStatus.Recieved.Name);
            var paymentDTOList = new List<PaymentDTO>();
            foreach (var payment in paymentList)
            {
                paymentDTOList.Add(_mapper.Map<PaymentDTO>(payment));
            }
            return paymentDTOList.AsEnumerable();
        }

        public async Task<bool> ProcessPayment(PaymentDTO paymentDTO)
        {
            var check = await _unitOfWork.Invoices.Find(paymentDTO.InvoiceID);
            if (check != null)
            {
                var payment = _mapper.Map<Payment>(paymentDTO);
                _unitOfWork.Payments.Update(payment);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            var check = await _unitOfWork.Invoices.Find(invoiceDTO.ID);
            if (check != null)
            {
                var invoice = _mapper.Map<Invoice>(invoiceDTO);
                _unitOfWork.Invoices.Update(invoice);
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
