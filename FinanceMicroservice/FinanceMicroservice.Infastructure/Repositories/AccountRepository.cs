﻿using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Application.Repositories;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Infastructure.Context;

namespace FinanceMicroservice.Infastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {

        }

    }
}
