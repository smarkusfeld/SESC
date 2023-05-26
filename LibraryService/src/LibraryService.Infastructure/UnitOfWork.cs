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
        private IBookAuthorRepository _bookauthors;
        private IBookRepository _books;
        private IBookCopyRepository _bookitems;
        private ILoanRepository _loans;
        private IClassificationRepository _classifications;
        private IBookClassificationRepository _bookclassifications;
        private IIdentifierRepository _identifiers;
        private IBookIdentifierRepository _bookidentifiers;
        private ISubjectRepository _subjects;
        private IBookSubjectRepository _booksubjects;
        private IPublisherRepository _publishers;
        private IBookPublisherRepository _bookpublishers;
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

        public IBookAuthorRepository BookAuthors
        {
            get
            {
                _bookauthors ??= new BookAuthorRepository(_dbContext);
                return _bookauthors;
            }
        }


        public IBookCopyRepository BookCopies
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

        public IBookSubjectRepository BookSubjects
        {
            get
            {
                _booksubjects ??= new BookSubjectRepository(_dbContext);
                return _booksubjects;
            }
        }

        public IBookPublisherRepository BookPublishers
        {
            get
            {
                _bookpublishers ??= new BookPublisherRepository(_dbContext);
                return _bookpublishers;
            }
        }

        public IBookIdentifierRepository BookIdentifers
        {
            get
            {
                _bookidentifiers ??= new BookIdentifierRepository(_dbContext);
                return _bookidentifiers;
            }
        }

        public IBookClassificationRepository BookClassifications
        {
            get
            {
                _bookclassifications ??= new BookClassificationRepository(_dbContext);
                return _bookclassifications;
            }
        }


        public ISubjectRepository Subjects
        {
            get
            {
                
               _subjects ??= new SubjectRepository(_dbContext);
                return _subjects;
            }
        }



        public IPublisherRepository Publishers
        {
            get
            {
                _publishers ??= new PublisherRepository(_dbContext);
                return _publishers;
            }
        }


        public IIdentifierRepository Identifers
        {
            get
            {
                _identifiers ??= new IdentifierRepository(_dbContext);
                return _identifiers;
            }
        }

        public IClassificationRepository Classifications
        {
            get
            {
                _classifications ??= new ClassificationRepository(_dbContext);
                return _classifications;
            }
        }


        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _accounts = Accounts;
            _books = Books;
            _bookitems = BookCopies;
            _loans = Loans;
            _authors = Authors;
            _bookauthors = BookAuthors;
            _classifications = Classifications;
            _bookclassifications = BookClassifications;
            _identifiers = Identifers;
            _bookidentifiers = BookIdentifers;

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