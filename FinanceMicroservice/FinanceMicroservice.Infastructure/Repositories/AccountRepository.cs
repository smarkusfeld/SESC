using FinanceMicroservice.Core.Interfaces;
using FinanceMicroservice.Core.Models;

namespace FinanceMicroservice.Infastructure.Repositories { 
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
