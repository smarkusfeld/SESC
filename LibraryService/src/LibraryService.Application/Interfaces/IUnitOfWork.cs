using LibraryService.Domain.Entities;
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
        IBookSubjectRepository BookSubjects { get; }
        IBookPublisherRepository BookPublishers { get; }
        IBookIdentifierRepository BookIdentifers { get; }
        IBookClassificationRepository BookClassifications { get; }
        ISubjectRepository Subjects { get; }
        IPublisherRepository Publishers { get; }
        IIdentifierRepository Identifers { get; }
        IClassificationRepository Classifications { get; }
        IAuthorRepository Authors { get; }
        IBookAuthorRepository BookAuthors { get; }
        IBookCopyRepository BookCopies { get; }
        ILoanRepository Loans { get; }
        int Save();

    }
}
