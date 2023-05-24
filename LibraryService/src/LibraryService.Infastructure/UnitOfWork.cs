using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private IAccountRepository _accounts;
        private IAuthorRepository _authors;
        private ITitleAuthorRepository _titleauthors;
        private IBookRepository _books;
        private IBookCopyRepository _bookitems;
        private ILoanRepository _loans;

        public IAccountRepository Accounts
        {
            get
            {
                _accounts ??= new AccountRepository(_dbContext);
                return _accounts;
            }
        }

        public IBookRepository Books
        {
            get
            {
                _books ??= new BookRepository(_dbContext);
                return _books;
            }
        }

        public IAuthorRepository Authors
        {
            get
            {
                _authors ??= new AuthorRepository(_dbContext);
                return _authors;
            }
        }

        public ITitleAuthorRepositoryBookAuthors
        {
            get
            {
                _titleauthors ??= newBookAuthorRepository(_dbContext);
                return _titleauthors;
            }
        }


        public IBookCopyRepository BookCopys
        {
            get
            {
                _bookitems ??= new BookCopyRepository(_dbContext);
                return _bookitems;
            }
        }

        public ILoanRepository Loans
        {
            get
            {
                _loans ??= new LoanRepository(_dbContext);
                return _loans;
            }
        }

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _accounts = Accounts;
            _books = Books;
            _bookitems = BookCopys;
            _loans = Loans;
            _authors = Authors;
            _titleauthors =BookAuthors;
        }

        /// <summary>
        /// Completes the unit of work, saving all repository changes to the underlying data-store.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public int Save() =>_dbContext.SaveChanges();   

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <returns><see cref="ValueTask"/></returns>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing"></param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}