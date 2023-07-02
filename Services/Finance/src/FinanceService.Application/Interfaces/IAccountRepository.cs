using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        
    }
}
