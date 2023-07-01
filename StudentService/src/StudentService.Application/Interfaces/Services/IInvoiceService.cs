using StudentService.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Check if student as any outsanding invoices
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<bool> HasOutstandingBalance(string studentId);


        /// <summary>
        /// Create Invoice for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<bool> CreateInvoice(string studentId);

        /// <summary>
        /// Get all outstanding invoices for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IEnumerable<OutstandingInvoiceDTO>> GetOutstandInvoices(string studentId);

        /// <summary>
        /// Get student outstanding balance
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<float> GetOutstandingBalance(string studentId);
    }
}
