using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinanceMicroservice.Core.Infastructure;
using FinanceMicroservice.Core.Interfaces;
using FinanceMicroservice.Core.Models;
using FinanceMicroservice.Infastructure.Repositories;
using FinanceMicroservice.Services.Interfaces;

namespace FinanceMicroservice.Infastructure
{
    
    public class AccountService : IFinanceService<AccountDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Add(AccountDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AccountDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDTO> Find(Expression<Func<AccountDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
