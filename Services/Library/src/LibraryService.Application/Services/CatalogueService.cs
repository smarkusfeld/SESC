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

        






    }
}
