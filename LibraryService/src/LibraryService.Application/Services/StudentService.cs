﻿using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class StudentService : IStudentService
    {
        public Task<LoanDTO> CreateNewLoan(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoanDTO>> GetLoanHistory(int accountID)
        {
            throw new NotImplementedException();
        }

        public Task<LoanDTO> ReturnBook(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}
