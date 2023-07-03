using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;

namespace LibraryService.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private IAccountRepository _accounts;
        private IBookRepository _books;
        //private IBookCopyRepository _copies;
        private IAuthorRepository _authors;
        private IPublisherRepository _publishers;
        private ISubjectRepository _subjects;
        private ILoanRepository _loans;
        private IReservationRepository _reservations;
        private bool disposed;
        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _accounts = Accounts;
            _books = Books;
            _authors = Authors;
            _publishers = Publishers;
            _subjects = Subjects;
            _reservations = Reservations;
            _loans = Loans;
            
           
        }
        public IAccountRepository Accounts => _accounts ??= new AccountRepository(_dbContext);
        public IBookRepository Books
        {
            get
            {
                if (_books == null)
                {
                    _books = new BookRepository(_dbContext);
                }
                return _books;
            }
        }
        public IAuthorRepository Authors
        {
            get
            {
                if (_authors == null)
                {
                    _authors = new AuthorRepository(_dbContext);
                }
                return _authors;
            }
        }
        public IPublisherRepository Publishers
        {
            get
            {
                if (_publishers == null)
                {
                    _publishers = new PublisherRepository(_dbContext);
                }
                return _publishers;
            }
        }
        public ISubjectRepository Subjects
        {
            get
            {
                if (_subjects == null)
                {
                    _subjects = new SubjectRepository(_dbContext);
                }
                return _subjects;
            }
        }
        public ILoanRepository Loans
        {
            get
            {
                if (_loans == null)
                {
                    _loans = new LoanRepository(_dbContext);
                }
                return _loans;
            }
        }
        public IReservationRepository Reservations
        {
            get
            {
                if (_reservations == null)
                {
                    _reservations = new ReservationRepository(_dbContext);
                }
                return _reservations;
            }
        }
        /// <summary>
        /// Completes the unit of work, saving all repository changes to the underlying data-store.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
       


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
            if (disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }



        /// <summary>
        /// Method to rollback database changes to its previous state
        /// </summary>
        /// <returns></returns>
        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }
    }
}