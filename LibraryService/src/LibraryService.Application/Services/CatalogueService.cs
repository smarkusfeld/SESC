using AutoMapper;

using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Common.Exceptions;

namespace LibraryService.Application.Services
{
    public class CatalogueService : ICatalogueService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       // private readonly IISBNService _openLibrary;
        public CatalogueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_openLibrary = openLibrary;
        }

        public async Task<BookDTO> AddBookByISBN(string isbn)
        {
            //see if book already exists in the library 
            var bookRecord = await _unitOfWork.Books.GetAsync(isbn);
            //if book exits add new copy
            if(bookRecord != null)
            {
               return await AddBookCopy(bookRecord);  
            }
            //if book does not already exist get details 
            //var newBookRecord = await GetOpenLibraryBookDetail(isbn);
            //add new book
            //if(newBookRecord != null)
            //{
                //return await CreateNewBookRecord(newBookRecord);
            //}
            throw new BadRequestException("Unable to resolve isbn");
        }
        public async Task<BookDTO> GetBook(string isbn)
        {
            var book = await _unitOfWork.Books.GetAsync(isbn);
            if (book != null)
            {
                return _mapper.Map<BookDTO>(book);
            }
            throw new KeyNotFoundException($"No book record for {isbn}");
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthors()
        {
            var response =  await _unitOfWork.Authors.GetAllAsync();
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<AuthorDTO>();
            }
            else
            {
                
                return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(response);
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var response = await _unitOfWork.Books.GetAllAsync();
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<BookDTO>();
            }
            else
            {

                return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(response);
            }
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublishers()
        {
            var response  = await _unitOfWork.Publishers.GetAllAsync();
            
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<PublisherDTO>();
            }
            else
            {

                return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDTO>>(response);
            }
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllSubjects()
        {
            var response = await _unitOfWork.Subjects.GetAllAsync();
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<SubjectDTO>();
            }
            else
            {

                return _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(response);
            }
        }

        public Task<AuthorDTO> UpdateAuthor(AuthorDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<BookDTO>UpdateBook(BookDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<PublisherDTO> UpdatePublisher(PublisherDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<SubjectDTO> UpdateSubject(SubjectDTO dto)
        {
            throw new System.NotImplementedException();
        }
        public async Task<BookDTO> AddBookCopy(Book bookRecord)
        {
            bookRecord.AddBookCopy();
            var updateRecord = await _unitOfWork.Books.AddCopyAsync(bookRecord);
            if (updateRecord != null)
            {
                var result = await _unitOfWork.Save();
                BookDTO bookDTO = _mapper.Map<BookDTO>(updateRecord);
                return result > 0 ? bookDTO : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create account.");
        }
        //public async Task<NewBookRecordDTO> GetOpenLibraryBookDetail(string isbn)
        //{
           // return await _openLibrary.GetBookDetails(isbn);
        //}

        public async Task<BookDTO> CreateNewBookRecord(NewBookRecordDTO newBookRecord)
        {
            var newBook = _mapper.Map<Book>(newBookRecord);
            
            foreach ( AuthorDTO author in newBookRecord.Authors)
            {
                var bookAuthor = await GetBookAuthor(author);
                newBook.AddBookAuthor(bookAuthor.Id, bookAuthor.FullName);
            }
            foreach (PublisherDTO publisher in newBookRecord.Publishers)
            {
                var bookPublisher = await GetBookPublisher(publisher);
                newBook.AddBookPublisher(bookPublisher.Id, bookPublisher.Name);
            }
            foreach (SubjectDTO subject in newBookRecord.Subjects)
            {
                var bookSubject = await GetBookSubject(subject);
                newBook.AddBookSubject(bookSubject.Id, bookSubject.Name);
            }
            var addedBook = await _unitOfWork.Books.AddAsync(newBook);
            if(addedBook != null) 
            {
                var result = await _unitOfWork.Save();
                var dto = _mapper.Map<BookDTO>(addedBook);
                return result > 0 ? dto : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create account.");
        }

        
        private async Task<Author> GetBookAuthor(AuthorDTO author)
        {
            var authorRecord = await _unitOfWork.Authors.GetByAsync(x => x.FullName == author.FullName);
            if(authorRecord == null)
            {
                authorRecord = await AddAuthor(author);
            }
            return authorRecord;
        }

        private async Task<Author> AddAuthor(AuthorDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            var add = await _unitOfWork.Authors.AddAsync(newAuthor);
            if(add != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? add : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create author.");
        }
        private async Task<Publisher> GetBookPublisher(PublisherDTO publisher)
        {
            var bookPublisher = await _unitOfWork.Publishers.GetByAsync(x => x.Name == publisher.Name);
            if (bookPublisher == null)
            {
                bookPublisher = await AddPublisher(publisher);
            }
            return bookPublisher;
        }

        private async Task<Publisher> AddPublisher(PublisherDTO publisher)
        {
            var newPublisher = _mapper.Map<Publisher>(publisher);
            var add = await _unitOfWork.Publishers.AddAsync(newPublisher);
            if (add != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? add : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create publisher.");
        }
        private async Task<Subject> GetBookSubject(SubjectDTO subject)
        {
            var bookSubject = await _unitOfWork.Subjects.GetByAsync(x => x.Name == subject.Name);
            if (bookSubject == null)
            {
                bookSubject = await AddSubject(subject);
            }
            return bookSubject;
        }

        private async Task<Subject> AddSubject(SubjectDTO subject)
        {
            var newSubject = _mapper.Map<Subject>(subject);
            var add = await _unitOfWork.Subjects.AddAsync(newSubject);
            if (add != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? add : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create subject.");
        }
    }
}
