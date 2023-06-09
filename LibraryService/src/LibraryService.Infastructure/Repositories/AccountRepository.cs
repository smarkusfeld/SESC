using LibraryService.Application.Interfaces;
using LibraryService.Domain.Models;
using LibraryService.Domain.RepositoryInterfaces;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class AccountRepository : GenericRepository<AccountModel>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {
           
        }
       //add method for finding 
    }
   
}
