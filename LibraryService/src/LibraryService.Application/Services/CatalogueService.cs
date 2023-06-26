using AutoMapper;
using LibraryService.Application.Common.Exceptions;
using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibraryService.Domain.Entities;
using NotImplementedException = LibraryService.Application.Common.Exceptions.NotImplementedException;

namespace LibraryService.Application.Services
{
    public class CatalogueService : ICatalogueService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public CatalogueService(IUnitOfWork unitOfWork, IMapper mapper, HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClient = httpClient;
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
            var newBookRecord = await GetOpenLibraryBookDetail(isbn);
            //add new book
            if(newBookRecord != null)
            {
                return await CreateNewBookRecord(newBookRecord);
            }
            throw new InvalidParameterException("Bad Request. Unable to resolve isbn");
        }
        public async Task<BookDTO> GetBook(string isbn)
        {
            var book = await _unitOfWork.Books.GetAsync(isbn);
            if (book != null)
            {
                return _mapper.Map<BookDTO>(book);
            }
            throw new BadKeyException("book", isbn);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthors()
        {
            var all =  await _unitOfWork.Authors.GetAllAsync();
            if(all != null)
            {
                return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(all);
            }
            throw new NoRecordsFoundException("author");
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var all = await _unitOfWork.Books.GetAllAsync();
            if (all != null)
            {
                return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(all);
            }
            throw new NoRecordsFoundException("book");
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublishers()
        {
            var all = await _unitOfWork.Publishers.GetAllAsync();
            if (all != null)
            {
                return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDTO>>(all);
            }
            throw new NoRecordsFoundException("publisher");
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllSubjects()
        {
            var all = await _unitOfWork.Subjects.GetAllAsync();
            if (all != null)
            {
                return _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(all);
            }
            throw new NoRecordsFoundException("subjects");
        }

        public Task<AuthorDTO> UpdateAuthor(AuthorDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO>UpdateBook(BookDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<PublisherDTO> UpdatePublisher(PublisherDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectDTO> UpdateSubject(SubjectDTO dto)
        {
            throw new NotImplementedException();
        }
        public async Task<BookDTO> AddBookCopy(Book bookRecord)
        {
            bookRecord.AddBookCopy();
            var updateRecord = await _unitOfWork.Books.AddCopyAsync(bookRecord);
            if (updateRecord != null)
            {
                var result = await _unitOfWork.Save();
                BookDTO bookDTO = _mapper.Map<BookDTO>(updateRecord);
                return result > 0 ? bookDTO : throw new UnableToSaveRecordException();
            }
            throw new InvalidParameterException("Bad Request. Unable to create account.");
        }
        public async Task<NewBookRecordDTO> GetOpenLibraryBookDetail(string isbn)
        {
            HttpResponseMessage Res = await _httpClient.GetAsync("books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json");
            List<string> details = new()
            {
                "Resquest Message: " + Res.RequestMessage,
                "Response Header: " + Res.Headers,
                "Reponse Body: " + Res.Content.ReadAsStringAsync().Result,
            };

            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var json = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api 
                JObject jsonObject = JObject.Parse(json);
                var data = jsonObject.SelectToken("ISBN:" + isbn).ToString();
                var result = JsonConvert.DeserializeObject<NewBookRecordDTO>(data, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

                if (result != null)
                {
                    return result;
                }
                throw new ApiFailureException("Unable to parse open library record", details, System.Net.HttpStatusCode.BadRequest);
            }

            string message = Res.ReasonPhrase ?? "Unsuccessful Request to OpenLibraryApi";

            throw new ApiFailureException(message, details, Res.StatusCode);
        }

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
                return result > 0 ? dto : throw new UnableToSaveRecordException();
            }
            throw new UnableToSaveRecordException();
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
                return result > 0 ? add : throw new UnableToSaveRecordException();
            }
            throw new InvalidParameterException("Bad Request. Unable to create author.");
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
                return result > 0 ? add : throw new UnableToSaveRecordException();
            }
            throw new InvalidParameterException("Bad Request. Unable to create publisher.");
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
                return result > 0 ? add : throw new UnableToSaveRecordException();
            }
            throw new InvalidParameterException("Bad Request. Unable to create subject.");
        }
    }
}
