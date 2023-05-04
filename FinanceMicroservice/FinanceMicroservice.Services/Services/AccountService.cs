using System;
using System.Linq.Expressions;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Application.Services
{

    public class AccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //create account

        //accountdto

        //getallaccounts

        //getbystudentid

        //create new account

        //upsert account

        //delete account

        //check account balance
    }
}
