using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
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
            var paymentList = await _unitOfWork.Payments.FindAllWhere(x => x.PaymentStatus == PaymentStatus.Recieved.ToString());
            var paymentDTOList = new List<PaymentDTO>();
            foreach (var payment in paymentList)
            {
                paymentDTOList.Add(_mapper.Map<PaymentDTO>(payment));
            }
            return paymentDTOList.AsEnumerable();
        }

        public async  Task<bool> ProcessPayment(PaymentDTO paymentDTO)
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
    }
}
