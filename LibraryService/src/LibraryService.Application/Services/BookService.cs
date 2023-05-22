using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryService.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBook(int isbn)
        {
            //see if book already exists in the library 
            var check = await (ISBNCheck(isbn));
            if (check)
            {
                //add new copy of exisitng book 
                var add = await AddBookItem(isbn);
                return add;
            }
            //create new book record
            BookDTO dto = await GetDetails(isbn);
            if (dto != null)
            {
                Book newBook = new Book()
                {
                    Title = dto.Title,
                    Copies = dto.Copies,
                    Year = dto.Year,
                    //add author logic

                };
                var add = _unitOfWork.Books.AddAsync(newBook);
                if (add != null)
                {
                    var result = _unitOfWork.Save();
                    if (result > 0)
                    {
                        var addCopy = await AddBookItem(isbn);
                        return addCopy;
                    }
                }
                return false;

            }
            return false;
        }

        public Task<LoanDTO> CreateNewLoan(int isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<LoanDTO> ReturnBook(int isbn)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> AddBookItem(int isbn)
        {
            try
            {
                BookItem bookItem = new BookItem
                {
                    ISBN = isbn
                };
                var add = await _unitOfWork.BookItems.AddAsync(bookItem);
                if (add != null)
                {
                    var result = _unitOfWork.Save();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> ISBNCheck(int isbn)
        {
            var book = await _unitOfWork.Books.GetByAsync(x => x.ISBN == isbn);
            return book != null;
        }

        private async Task<BookDTO> GetDetails(int isbn)
        {
            String url = "http://openlibrary.org/api/books?bibkeys=ISBN:" + isbn + "&jscmd=details&format=json";
            String json = new WebClient().DownloadString(url);
            JObject jsonObject = JObject.Parse(json);
            JToken details = jsonObject.SelectToken("ISBN:" + isbn + ".details");
            String title = (string)details["title"];
            int year = (int)details["publishDate"];
            List<string>authorList = new List<string>();
            var authors= jsonObject.SelectToken("authors");
            foreach (var author in authors) {

                string name = (string)authors["name"];
                authorList.Add(name);
            }
            //todo add author functionality
            return new BookDTO()
            {
                ISBN = isbn,
                Title = title,
                Year = year,
                Copies = 1,
                Authors = authorList

            };

        }
    }
}
