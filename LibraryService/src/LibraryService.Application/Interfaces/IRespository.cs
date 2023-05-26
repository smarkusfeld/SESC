using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

    }
    public interface IBookAuthorRepository : IGenericRepository<BookAuthor>
    {

    }
    public interface IAuthorRepository : IGenericRepository<Author>
    {

    }
    public interface IBookRepository : IGenericRepository<Book>
    {

    }
    public interface IBookCopyRepository : IGenericRepository<BookCopy>
    {

    }
    public interface ILoanRepository : IGenericRepository<Loan>
    {

    }
    public interface ISubjectRepository : IGenericRepository<Subject>
    {

    }
    public interface IBookSubjectRepository : IGenericRepository<BookSubject>
    {

    }
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {

    }
    public interface IClassificationRepository : IGenericRepository<Classification>
    {

    }
    public interface IIdentifierRepository : IGenericRepository<Identifier>
    {

    }
    public interface IBookPublisherRepository : IGenericRepository<BookPublisher>
    {

    }
    public interface IBookClassificationRepository : IGenericRepository<BookClassification>
    {

    }
    public interface IBookIdentifierRepository : IGenericRepository<BookIdentifier>
    {

    }
}
