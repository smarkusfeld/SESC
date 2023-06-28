using LibraryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces.Repositories
{
    ///<summary>
    /// This interface defines a contract for the unit of work class
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IBookRepository Books { get; }
        ISubjectRepository Subjects { get; }
        IPublisherRepository Publishers { get; }
        IAuthorRepository Authors { get; }
        //IBookCopyRepository BookCopies { get; }
        ILoanRepository Loans { get; }
        IReservationRepository Reservations { get; }

        //IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> Save();
        Task Rollback();
    }
}
