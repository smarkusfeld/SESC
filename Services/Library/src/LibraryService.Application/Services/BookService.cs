using LibraryService.Application.Models;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Common.Exceptions;
using LibraryService.Application.Interfaces.Repositories;
using AutoMapper;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(HttpClient httpClient, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<BookDTO> AddBookByISBN(string isbn)
        {
            //see if book already exists in the library 
            var bookRecord = await _unitOfWork.Books.GetAsync(isbn);
            //if book exits add new copy
            if (bookRecord != null)
            {
                return await AddBookCopy(bookRecord);
            }
            //if book does not already exist get details 
            var newBookRecord = await GetBookDetails(isbn);
            //add new book
            if (newBookRecord != null)
            {
                return await CreateNewBookRecord(newBookRecord);
            }
            throw new BadRequestException("Unable to resolve isbn");
        }

        public async Task<BookDTO> CreateNewBookRecord(NewBookRecordDTO newBookRecord)
        {
            var newBook = _mapper.Map<Book>(newBookRecord);

            foreach (AuthorDTO author in newBookRecord.Authors)
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
            if (addedBook != null)
            {
                var result = await _unitOfWork.Save();
                var dto = _mapper.Map<BookDTO>(addedBook);
                return result > 0 ? dto : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create account.");
        }

        public async Task<NewBookRecordDTO> GetBookDetails(string isbn)
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
                throw new BadRequestException("Unable to parse open library record");
            }

            string message = Res.ReasonPhrase ?? "Unsuccessful Request to OpenLibraryApi";

            throw new InvalidResponseException(message, details);
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

        private async Task<Author> GetBookAuthor(AuthorDTO author)
        {
            var authorRecord = await _unitOfWork.Authors.GetByAsync(x => x.FullName == author.FullName);
            authorRecord ??= await AddAuthor(author);
            return authorRecord;
        }

        private async Task<Author> AddAuthor(AuthorDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            var add = await _unitOfWork.Authors.AddAsync(newAuthor);
            if (add != null)
            {
                var result = await _unitOfWork.Save();
                return result > 0 ? add : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create author.");
        }

        private async Task<Publisher> GetBookPublisher(PublisherDTO publisher)
        {
            var bookPublisher = await _unitOfWork.Publishers.GetByAsync(x => x.Name == publisher.Name);
            bookPublisher ??= await AddPublisher(publisher);
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
            bookSubject ??= await AddSubject(subject);
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
