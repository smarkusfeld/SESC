using FinanceService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Interfaces
{ ///<summary>
  /// This interface defines a contract for invoice services.
  ///</summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Method to make a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> MakePayment(PaymentDTO paymentDTO);
        /// <summary>
        /// Method to cancel a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> CancelPayment(PaymentDTO paymentDTO);

        /// <summary>
        /// Method to make a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> ProcessPayment(PaymentDTO paymentDTO);

        /// <summary>
        /// Method returns all unprocessed payments
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<IEnumerable<PaymentDTO>> PaymentsToBeProcessed();
        Task<PaymentDTO> FindPaymentByReference(string reference);
        Task<int> FindInvoiceID(string reference);
    }
}
