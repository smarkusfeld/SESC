using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {
           
        }
        

    }

}
