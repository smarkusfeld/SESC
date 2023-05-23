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
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
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
        public async Task<int> CheckBookCount(int isbn)
        {
            try
            {
                var copies = await _unitOfWork.BookItems.GetAllWhereAsync(x => x.ISBN == isbn && x.IsAvailable == true);
                return copies.Count();
            }
            catch
            {
                return 0;
            }
        }
        public async Task<BookItemDTO> GetAvailableBookItem(int isbn)
        {
            try
            {
                var item = await _unitOfWork.BookItems.GetByAsync(x => x.ISBN == isbn && x.IsAvailable == true);
                return new BookItemDTO
                {
                    ID = item.ID,
                    ISBN = item.ISBN,
                    IsAvailable = item.IsAvailable,
                };
            }
            catch
            {
                return 0;
            }
        }
        private void UpdateBookItem(BookItem bookItem, bool IsAvailable)
        {
            
            bookItem.IsAvailable = IsAvailable;
            _unitOfWork.BookItems.Update(bookItem);
            _unitOfWork.Save();
        }
        public async Task<AccountDTO> GetLibraryAccount(string studentid)
        {
            try
            {
                var account = await _unitOfWork.Accounts.GetByAsync(x => x.StudentID == studentid);
                return new AccountDTO
                {
                    ID = account.ID,
                    StudentID = account.StudentID,
                    Pin = account.Pin,

                };

            }
            catch
            {
                return null;
            }
            
        }
        public async Task<bool> CreateNewLoan(int accountID, int bookItemID)
        {
            try
            {                
                Loan newLoan = new Loan
                {
                    AccountID = accountID,
                    BookItemID = bookItemID,
                    DateBorrowed = DateTime.Now,

                };
                var result = await _unitOfWork.Loans.AddAsync(newLoan);
                if(result!=null)
                {
                    _unitOfWork.Save();
                    var bookItem = await _unitOfWork.BookItems.GetByAsync(x => x.ID == bookItemID);
                    UpdateBookItem(bookItem, false);
                    
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }            
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            var booklist = new List<BookDTO>();
            foreach (var book in books)
            {
                booklist.Add(new BookDTO()
                {
                    Title = book.Title,
                    Copies = book.Copies,
                    Year = book.Year,
                    ISBN = book.ISBN,
                    //add authors
                });
            }
            return booklist.AsEnumerable();
        }
        public async Task<LoanDTO> FindLoan(string studentid, int isbn)
        {
            try
            {
                var loanList = await _unitOfWork.Loans.GetAllWhereAsync(x => x.BookItem.ISBN == isbn && x.Account.StudentID == studentid);
                var loan = loanList.Where(x => x.DateReturned == null).FirstOrDefault();
                return new LoanDTO
                {
                    ID = loan.ID,
                    AccountID = loan.Account.ID,
                    BookItemID = loan.ID,
                    DateBorrowed = loan.DateBorrowed,
                    DateReturned = loan.DateReturned,
                };
            }
            catch
            {
                return null;
            }

        }
        public async Task<bool> ReturnLoan(LoanDTO dto)
        {
            try
            {
                var loan = await _unitOfWork.Loans.GetAsync(dto.ID);
                loan.DateReturned = DateTime.Now;
                _unitOfWork.Loans.Update(loan);
                _unitOfWork.Save();
                UpdateBookItem(loan.BookItem, true);
                return true;
            }
            catch { return false; }
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
