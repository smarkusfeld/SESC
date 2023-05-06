using FinanceMicroservice.Application.DTOs;

namespace FinanceMicroservice.Application.Interfaces
{
    ///<summary>
    /// This interface defines a contract for invoice services
    ///</summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// This method creates a new invoice
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> CreateInvoice(InvoiceDTO invoiceDTO);

        /// <summary>
        /// This method returns all invoices  
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<IEnumerable<InvoiceDTO>> GetAllInvoices();

        /// <summary>
        /// This method returns all outstanding invoices  
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the outstanding invoice DTOs
        /// </returns>
        Task<IEnumerable<InvoiceDTO>> GetAllOutstandingInvoices();

        /// <summary>
        /// This method returns all overdue invoices  
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the overdue invoice DTOs
        /// </returns>
        Task<IEnumerable<InvoiceDTO>> GetAllOverdueInvoices();

        /// <summary>
        /// This method returns an invoice from the invoice id
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the invoiceDTO
        /// </returns>
        Task<InvoiceDTO> GetInvoiceById(int invoiceID);
        /// <summary>
        /// This method returns an invoice from the student id
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the invoiceDTO
        /// </returns>
        Task<InvoiceDTO> GetInvoiceByReference(string reference);
        /// <summary>
        /// Method to update an invoice
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> UpdateInvoice(InvoiceDTO invoiceDTO);
        /// <summary>
        /// Method to delete an invoice
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<bool> DeleteInvoice(int invoiceID);
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

    }
}
