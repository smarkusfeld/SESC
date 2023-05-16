using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Mapper;
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
            var check = await _unitOfWork.Payments.GetAsync(paymentDTO.ID);
            if (check != null)
            {

                paymentDTO.Status = PaymentStatus.Cancelled;
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
            paymentDTO.Status = PaymentStatus.Recieved;
            var payment = _mapper.Map<Payment>(paymentDTO);
            await _unitOfWork.Payments.AddAsync(payment);
            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
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
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<PaymentDTO> FindPaymentByReference(string reference)
        {
            var paymentDTO = await _unitOfWork.Payments.GetByAsync(x => x.PaymentReference == reference);
            return _mapper.Map<PaymentDTO>(paymentDTO);
        }
        public async Task<int> FindInvoiceID(string reference)
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

    }
}
