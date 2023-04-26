using System.Linq.Expressions;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application.Services
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
