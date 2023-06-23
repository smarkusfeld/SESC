using LibraryService.Application.Models;
using LibraryService.Application.Interfaces;

namespace LibraryService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public Task<bool> CreateAccount(string studentID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountDTO>> GetAllStudentAccounts()
        {
            var accounts = await _unitOfWork.Accounts.GetAllAsync();
            List<AccountDTO> studentacccounts = new List<AccountDTO>();
            foreach (var account in accounts) 
            {
                ///add conversion

                studentacccounts.Add(new AccountDTO());

            }
            return studentacccounts;
        }

        public Task<bool> Login(AccountDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAccount(string studentID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterStudent(string studentID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(string studentID)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAccount(AccountDTO dto)
        {
            if (dto.StudentId.Trim().Length == 0)
            {
                //_validatonDictionary.AddError("StudentID", "Name is required.");
            }
            var acccount = _unitOfWork.Accounts.GetByAsync(x=>x.StudentId == dto.StudentId);
            if (acccount != null)
            {
                //_validatonDictionary.AddError("StudentID", "Account already associated with acccount");
            }

            //if (student.Description.Trim().Length == 0)
            // _validatonDictionary.AddError("Description", "Description is required.");
            return true;
        }
    }
}
