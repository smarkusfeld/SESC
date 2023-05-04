using System;
using System.Linq.Expressions;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Application.Services
{

    public class AccountService : GenericService<AccountDTO,Account>, IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //check records 
        public bool IsAccount(int id) => _unitOfWork.Accounts.Exists(id);
        public bool IsInvoice(int id) => _unitOfWork.Invoices.Exists(id);
        public bool IsPayment(int id) => _unitOfWork.Payments.Exists(id);

    

        public override bool Delete(AccountDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AccountDTO> GetAll()
        {
            throw new NotImplementedException();
        }
        public override ICollection<AccountDTO> Filter(Expression<Func<AccountDTO, bool>> expression)
        {
            //parse expression 
            throw new NotImplementedException();
        }

        public ICollection<AccountDTO> getOutstanding()
        {
            throw new NotImplementedException();
        }

        public override AccountDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override AccountDTO GetByStudentId(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(AccountDTO dto)
        {
            throw new NotImplementedException();
        }

        public override bool Upsert(AccountDTO dto)
        {
            throw new NotImplementedException();
        }

        protected override AccountDTO DTO(Account enity)
        {
            return new AccountDTO
            {
                ID = enity.ID,
                StudentID = enity.StudentID,
                HasOutstandingBalance = enity.HasOutstandingBalance,
            };
        }

        protected override Account Model(AccountDTO dto)
        {
            return new Account
            {
                ID = dto.ID,
                StudentID = dto.StudentID,
                HasOutstandingBalance = dto.HasOutstandingBalance,
            };
        }

        public override AccountDTO GetByStudent(int studentid)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AccountDTO> Index(string sortOrder)
        {
            throw new NotImplementedException();
        }

        public override AccountDTO Create(AccountDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
