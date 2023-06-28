using LibraryService.Application.Models;
using AutoMapper;
using LibraryService.Domain.Entities;
using LibraryService.Application.Common.Exceptions;
using LibraryService.Domain.Common.Enums;
using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Interfaces;

namespace LibraryService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<AccountDTO> CreateAccount(string id, string typename)
        {
            AccountType type;
            if (!Enum.TryParse(typename, true, out type))
            {
                throw new BadRequestException("Invalid Account Type");
            }
            
            //check if account exists
            var check = await _unitOfWork.Accounts.GetAsync(id);

            if (check != null)
            {
                throw new BadRequestException($"ID {id} already associated with an account");
            }
            Account newAccount = new Account { AccountId = id, AccountType = type };
            var addAccount = await _unitOfWork.Accounts.AddAsync(newAccount);
            if (addAccount != null)
            {
                var result = await _unitOfWork.Save();
                AccountDTO newDTO = _mapper.Map<AccountDTO>(addAccount);
                return result > 0 ? newDTO : throw new MySQLException();
            }
            throw new BadRequestException("Unable to create account.");
        }
        public async Task<bool> UpdateAccountPin(string id, string oldPin, string newPin)
        {
            //check if account exists
            var account = await _unitOfWork.Accounts.GetAsync(id);

            if (account != null)    
            {
                List<string> errors = new();
                //validate request
                if (int.TryParse(oldPin, out int old))
                {
                    errors.Add($"Incorrect format for {oldPin}. Pin number must be numerical and between 6-12 digits");
                }
                if (int.TryParse(newPin, out int pin))
                {
                    errors.Add($"Incorrect format for {oldPin}. Pin number must be numerical and between 6-12 digits");
                }
                if (newPin.Trim().Length <= 6 || newPin.Trim().Length >= 12)
                {
                    errors.Add("New Pin must be between 6 and 12 digits");
                }
                if (pin == old)
                {
                    errors.Add("New pin must be different from old pin");

                }
                if (account.Pin != old)
                {
                    throw new BadRequestException("Incorrect Pin Number");
                }
                if(!errors.Any()) { throw new BadRequestException("Invalid Request",errors); }

                //update account
                account.Pin = pin;
                var updateAccount = _unitOfWork.Accounts.UpdateAsync(account);
                if (updateAccount != null)
                {
                    var result = await _unitOfWork.Save();
                    return result > 0 ? true: throw new MySQLException();
                }
                throw new BadRequestException("Unable to update account.");
            }           
            throw new KeyNotFoundException($"No account found for id {id}");
        }
        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var response = await _unitOfWork.Accounts.GetAllAsync();
            if (response is null)
            {
               throw new MySQLException("MySQL data null");
            }
            else if(!response.Any())
            {

                return Enumerable.Empty<AccountDTO>();
            }
            else                
            {
                IEnumerable<AccountDTO> accountDtoList = _mapper.Map<Account[], IEnumerable<AccountDTO>>(response.ToArray());
                return accountDtoList;
            }          
         
        }
        public async Task<IEnumerable<AccountDTO>> GetAllAccountsByType(string typename)
        {
            AccountType type;           
            if (Enum.TryParse(typename, true, out type))
            {
                var response = await _unitOfWork.Accounts.GetAllWhereAsync(x=>x.AccountType == type);
                if (response is null)
                {
                    throw new MySQLException("MySQL data null");
                }
                else if (!response.Any())
                {

                    return Enumerable.Empty<AccountDTO>();
                }
                else
                {
                    IEnumerable<AccountDTO> accountDtoList = _mapper.Map<Account[], IEnumerable<AccountDTO>>(response.ToArray());
                    return accountDtoList;
                }

            }
            else
            {

                throw new BadRequestException("Invalid Account Type");
            }
            

        }

        public async Task<IEnumerable<LoanDTO>> GetAllCurrentLoans()
        {
            var response = await _unitOfWork.Loans.GetAllWhereAsync(x => x.IsComplete == false);
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<LoanDTO>();
            }
            else
            {
                IEnumerable<LoanDTO> dtoList = _mapper.Map<Loan[], IEnumerable<LoanDTO>>(response.ToArray());
                return dtoList;
            }
        }

        public async Task<IEnumerable<LoanDTO>> GetAllOverdueLoans()
        {
            var response = await _unitOfWork.Loans.GetAllWhereAsync(x => x.IsComplete == false);
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<LoanDTO>();
            }
            else
            {
                var overdue = response.Where(x => x.Status == LoanStatus.Overdue);
                IEnumerable<LoanDTO> dtoList = _mapper.Map<Loan[], IEnumerable<LoanDTO>>(overdue.ToArray());
                return dtoList;
            }
        }

        public async Task<IEnumerable<LoanDTO>> GetLoanHistory(string accountID)
        {
            var response = await _unitOfWork.Loans.GetAllWhereAsync(x=> x.AccountId == accountID);
            if (response is null)
            {
                throw new MySQLException("MySQL data null");
            }
            else if (!response.Any())
            {

                return Enumerable.Empty<LoanDTO>();
            }
            else
            {
                IEnumerable<LoanDTO> dtoList = _mapper.Map<Loan[], IEnumerable<LoanDTO>>(response.ToArray());
                return dtoList;
            }
        }

        public async Task<IEnumerable<LoanDTO>> GetAccountActiveLoans(string accountID)
        {
            var accountLoans = await GetLoanHistory(accountID);
            if (!accountLoans.Any())
            {
                return Enumerable.Empty<LoanDTO>();
            }
            return accountLoans.Where(x => x.IsComplete == false);             
        }

        public async Task<IEnumerable<LoanDTO>> GetAccountOverdueLoans(string accountID)
        {
            var accountLoans = await GetLoanHistory(accountID);
            if (!accountLoans.Any())
            {
                return Enumerable.Empty<LoanDTO>();
            }
            return accountLoans.Where(x => x.Status == LoanStatus.Overdue);
        }

        
    }
}
