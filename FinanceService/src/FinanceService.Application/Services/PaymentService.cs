using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Mapper;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<bool> CancelPayment(PaymentDTO paymentDTO)
        {
            var check = await _unitOfWork.Payments.GetAsync(paymentDTO.ID);
            if (check != null)
            {

                paymentDTO.Status = PaymentStatus.Cancelled;
                var payment = _mapper.Map<Payment>(paymentDTO);
                _unitOfWork.Payments.Update(payment);
                var result = _unitOfWork.Save();

                if (result > 0)
                {
                    var dto = await UpdateInvoice(paymentDTO.InvoiceID);
                    var updated = _mapper.Map<Invoice>(dto);
                    _unitOfWork.Invoices.Update(updated);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> MakePayment(PaymentDTO paymentDTO)
        {
            //create reference number
            DateTime date = DateTime.Now;
            string refnum = date.ToString("YYmmddHHmmssff") + paymentDTO.InvoiceID.ToString();
            string refalpha = "p";
            string payref = refalpha + refnum;
            //check reference
            var refcheck = await _unitOfWork.Payments.GetByAsync(x => x.PaymentReference == payref);
            while (refcheck != null)
            {
                int x = 0;
                payref = payref + x;
                x++;
                refcheck = await _unitOfWork.Payments.GetByAsync(x => x.PaymentReference == payref);
            }

            paymentDTO.PaymentReference = payref;
            paymentDTO.Status = PaymentStatus.Recieved;
            var payment = _mapper.Map<Payment>(paymentDTO);            
            await _unitOfWork.Payments.AddAsync(payment);
            var result = _unitOfWork.Save();

            if (result > 0)
            {
                var dto = await UpdateInvoice(paymentDTO.InvoiceID);
                var updated = _mapper.Map<Invoice>(dto);
                _unitOfWork.Invoices.Update(updated);
                _unitOfWork.Save();
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<PaymentDTO>> PaymentsToBeProcessed()
        {
            var paymentList = await _unitOfWork.Payments.GetAllWhereAsync(x => x.Status == PaymentStatus.Recieved);
            var paymentDTOList = new List<PaymentDTO>();
            foreach (var payment in paymentList)
            {
                paymentDTOList.Add(_mapper.Map<PaymentDTO>(payment));
            }
            return paymentDTOList.AsEnumerable();
        }

        public async  Task<bool> ProcessPayment(PaymentDTO paymentDTO)
        {
            var check = await _unitOfWork.Payments.GetAsync(paymentDTO.ID);
            if (check != null)
            {

                paymentDTO.Status = PaymentStatus.Processed;
                var payment = _mapper.Map<Payment>(paymentDTO);
                _unitOfWork.Payments.Update(payment);
                var result = _unitOfWork.Save();

                if (result > 0)
                {
                    var dto = await UpdateInvoice(paymentDTO.InvoiceID);
                    var updated = _mapper.Map<Invoice>(dto);
                    _unitOfWork.Invoices.Update(updated);
                    _unitOfWork.Save();
                    return true;
                }
                return false;

            }
            return false;
        }

        public async Task<PaymentDTO> FindPaymentByReference(string reference)
        {
            var paymentDTO = await _unitOfWork.Payments.GetByAsync(x => x.PaymentReference == reference);
            return _mapper.Map<PaymentDTO>(paymentDTO);
        }
        public async Task<int> GetInvoiceID(string reference)
        {
            var all = await _unitOfWork.Invoices.GetByAsync(x => x.Reference == reference);
            if (all != null)
            {
                return all.ID;
            }
            else
            {
                return 0;
            }
        }

        private async Task<InvoiceDTO> UpdateInvoice(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetAsync(id);
            InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);

            decimal paid = await TotalPaid(id);
            dto.Balance = dto.Total - paid;
            UpdateStatus(dto);
            return dto;

        }
        private InvoiceDTO UpdateStatus(InvoiceDTO dto)
        {
            if (dto.Balance == 0 && dto.Status != InvoiceStatus.Cancelled)
            {
                dto.Status = InvoiceStatus.Paid;
            }
            return dto;
        }
        private async Task<decimal> TotalPaid(int id)
        {
            
            try
            {
                var payments = await _unitOfWork.Payments.GetAllWhereAsync(x => x.InvoiceID == id
                                                                       && x.Status != PaymentStatus.Declined
                                                                       && x.Status != PaymentStatus.Cancelled);
                return payments.Select(x => x.Amount).Sum();
            }
            catch
            {
                return 0;
            }

        }

    }
}
