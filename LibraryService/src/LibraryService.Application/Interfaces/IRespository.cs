﻿using LibraryService.Domain.Entities;
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
    public interface ITitleAuthorRepository : IGenericRepository<BookAuthor>
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
}
