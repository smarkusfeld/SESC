using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Book> UpdateAsync(Book book)
        {
            //no need to include owned types -- eager loading performed automatically 
            var attached = await _set
                .Include(x=>x.BookAuthors)
                .Include(x => x.BookPublishers)
                .Include(x => x.BookAuthors)
                .SingleAsync(x=>x.ISBN==book.ISBN);

            _set.Entry(attached).State = EntityState.Detached;
            foreach (var bPub in attached.BookPublishers.ToList())
            {
                _context.Entry(bPub).State = EntityState.Detached;
            }
            foreach (var bAut in attached.BookAuthors.ToList())
            {
                _context.Entry(bAut).State = EntityState.Detached;
            }
            foreach (var bSub in attached.BookSubjects.ToList())
            {
                _context.Entry(bSub).State = EntityState.Detached;
            }
            
            var entry = _set.Attach(book);
            return book;

        }        
        public async Task<bool> UpdateCopiesAsync(Book book)
        {
            var attached = await _set
               .Include(x => x.BookCopies)
               .SingleAsync(x => x.ISBN == book.ISBN);
            _set.Entry(attached).State = EntityState.Detached;
            foreach (var copy in attached.BookCopies.ToList())
            {
                _context.Entry(copy).State = EntityState.Detached;
            }
            var entry = _set.Attach(book);
            return true;
        }
        public async Task<Book> AddCopyAsync(Book book)
        {
            var attached = await _set
                .Include(x => x.BookCopies)
                .SingleAsync(x => x.ISBN == book.ISBN);

            _set.Entry(attached).State = EntityState.Detached;
            foreach (var copy in attached.BookCopies.ToList())
            {
                _context.Entry(copy).State = EntityState.Detached;
            }
            var entry = _set.Attach(book);
            return book; 
            
        }

       


    }
}
