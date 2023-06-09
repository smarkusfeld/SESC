
using LibraryService.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Entities;

namespace LibraryService.Infastructure.RepositoryInterfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

    }
    public interface IBookAuthorRepository : IGenericRepository<BookAuthor>
    {

    }
    public interface IAuthorRepository : IGenericRepository<Author
        >
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
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {

    }
}
