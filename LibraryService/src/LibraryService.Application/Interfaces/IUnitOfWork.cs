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
        IAccountRepository Accounts { get; }
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        ITitleAuthorRepository TitleAuthors { get; }
        IBookItemRepository BookItems { get; }
        ILoanRepository Loans { get; }
        int Save();

    }
}
