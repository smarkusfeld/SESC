﻿using LibraryService.Domain.Entities;
using LibraryService.Domain.RepositoryInterfaces;
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
        ISubjectRepository Subjects { get; }
        IPublisherRepository Publishers { get; }

        IAuthorRepository Authors { get; }

        IBookCopyRepository BookCopies { get; }
        ILoanRepository Loans { get; }
        int Save();

    }
}
