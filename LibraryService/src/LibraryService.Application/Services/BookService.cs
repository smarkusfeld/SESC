﻿using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
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

        public async Task<bool> AddBook(string isbn)
        {
            //see if book already exists in the library 
            var check = await (ISBNCheck(isbn));
            if (check)
            {
                //add new copy of exisitng book 
                var add = await AddBookCopy(isbn);
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
                        var addCopy = await AddBookCopy(isbn);
                        return addCopy;
                    }
                }
                return false;

            }
            return false;
        }
        public async Task<int> CheckBookCount(string isbn)
        {
            try
            {
                string value = isbn.ToString();
                var copies = await _unitOfWork.BookCopies.GetAllWhereAsync(x => x.Book.BookIdentifiers.Any(y => y.Value == value && y.Identifier.Name.StartsWith("isbn")) && x.IsAvailable == true);
                return copies.Count();
            }
            catch
            {
                return 0;
            }
        }
        public async Task<BookCopyDTO> GetAvailableBookCopy(string isbn)
        {
            try
            {
                string value = isbn.ToString();
                var item = await _unitOfWork.BookCopies.GetByAsync(x => x.Book.BookIdentifiers.Any(y => y.Value == value && y.Identifier.Name.StartsWith("isbn")) && x.IsAvailable == true);
                return new BookCopyDTO
                {
                    ID = item.ID,
                    ISBN = item.ISBN,
                    IsAvailable = item.IsAvailable,
                };
            }
            catch
            {
                return null;
            }
        }
        private void UpdateBookCopy(BookCopy bookCopy, bool IsAvailable)
        {

            bookCopy.IsAvailable = IsAvailable;
            _unitOfWork.BookCopies.Update(bookCopy);
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
        public async Task<bool> CreateNewLoan(int accountID, int bookCopyID)
        {
            try
            {
                Loan newLoan = new Loan
                {
                    AccountID = accountID,
                    BookCopyID = bookCopyID,
                    DateBorrowed = DateTime.Now,

                };
                var result = await _unitOfWork.Loans.AddAsync(newLoan);
                if (result != null)
                {
                    _unitOfWork.Save();
                    var bookCopy = await _unitOfWork.BookCopies.GetByAsync(x => x.ID == bookCopyID);
                    UpdateBookCopy(bookCopy, false);

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
        public async Task<LoanDTO> FindLoan(string studentid, string isbn)
        {
            try
            {
                var loanList = await _unitOfWork.Loans.GetAllWhereAsync(x => x.BookCopy.ISBN == isbn && x.Account.StudentID == studentid);
                var loan = loanList.Where(x => x.DateReturned == null).FirstOrDefault();
                return new LoanDTO
                {
                    ID = loan.ID,
                    AccountID = loan.Account.ID,
                    BookCopyID = loan.ID,
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
                UpdateBookCopy(loan.BookCopy, true);
                return true;
            }
            catch { return false; }
        }

        private async Task<bool> AddBookCopy(string isbn)
        {
            try
            {
                BookCopy bookCopy = new BookCopy
                {
                    ISBN = isbn
                };
                var add = await _unitOfWork.BookCopies.AddAsync(bookCopy);
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
        private async Task<bool> ISBNCheck(string isbn)
        {
            string value = isbn.ToString();
            var book = await _unitOfWork.Books.GetByAsync(x => x.BookIdentifiers.Any(y=> y.Value == value && y.Identifier.Name.StartsWith("isbn")));
            return book != null;
        }

        private async Task<BookDTO> GetDetails(string isbn)
        {
            String url = "http://openlibrary.org/api/books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json";
            String json = new WebClient().DownloadString(url);
            JObject jsonObject = JObject.Parse(json);
            var data = jsonObject.SelectToken("ISBN:" + isbn).ToString();

            var record = JsonConvert.DeserializeObject<OpenLibraryRecord>(data, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        

            return new BookDTO();

        }

        public async Task<BookDTO> GetBookByISBN(string isbn)
        {
            string value = isbn.ToString();
            var book = await _unitOfWork.Books.GetByAsync(x => x.BookIdentifiers.Any(y => y.Value == value && y.Identifier.Name.StartsWith("isbn")));

            if (book != null)
            {
                return new BookDTO()
                {
                    Title = book.Title,
                    //add rest
                };
            }
            return null; 

        }

       // private async Task<IEnumerable<BookIdentifier>> BookIdentifiers()
        //{
           // string value = isbn.ToString();
            //return await _unitOfWork.BookIdentifers.GetAllOrderedAsync(predicate: x => x.Value == value, includeProperties: "Book, Identifier");
       // }

    }
        //clean up 

    
    }

