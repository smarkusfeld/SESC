using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    ///<summary>
    /// This interface defines a contract for the unit of work class
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {
        //IAccountRepository Accounts { get; }
        //IPaymentRepository Payments { get; }
        //IInvoiceRepository Invoices { get; }
        int Save();

    }
}
