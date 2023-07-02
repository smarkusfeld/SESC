using FinanceService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Interfaces
{
    ///<summary>
    /// This interface defines a contract for invoice services.
    ///</summary>
    public interface IInvoiceService
    {
        //view invoice by invoice id
        //view all invlices
        //create invoice
        //pay invoice
        //cancel invoice

        /// <summary>
        /// This method creates a new invoice
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the invoice reference
        /// </returns>
        Task<string> CreateInvoice(NewInvoiceDTO invoiceDTO);

        /// <summary>
        /// This method creates a new invoice for a tuttion fee
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<string> CreateTutitionInvoice(NewInvoiceDTO invoiceDTO);

        /// <summary>
        /// This method creates a new invoice for a libary fine
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        Task<string> CreateLibraryInvoice(NewInvoiceDTO invoiceDTO);
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

        //cancel invoice
        //pay invoice
        //get invoice by refference
        //processpayment
        //cancel payment 
        /// <summary>
        /// 
        /// </summary>
        /// <param name=" studentID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetAllInvoices(string studentID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetAllInvoices(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(string studentID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(int accountID);

        //private invoice  status
        //private  populate invoice blance 

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
    

        Task<bool> CancelInvoice(string reference);
        Task<bool> DeleteInvoice(int invoiceID);

        Task<bool>ReferenceCheck(string reference);
        



    }
}
