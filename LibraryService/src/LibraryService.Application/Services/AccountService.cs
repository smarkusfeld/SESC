using LibraryService.Application.Models;
using LibraryService.Application.Interfaces;
using AutoMapper;
using LibraryService.Domain.Entities;
using LibraryService.Application.Common.Exceptions;
using LibraryService.Domain.Common.Enums;
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
                throw new InvalidParameterException("$Bad Request Error.{typename} is not a valid account type");
            }
            
            //check if account exists
            var check = await _unitOfWork.Accounts.GetAsync(id);

            if (check != null)
            {
                throw new AccountAlreadyExistsException(id);
            }
            Account newAccount = new(id, type);           
            var addAccount = await _unitOfWork.Accounts.AddAsync(newAccount);
            if (addAccount != null)
            {
                var result = await _unitOfWork.Save();
                AccountDTO newDTO = _mapper.Map<AccountDTO>(addAccount);
                return result > 0 ? newDTO : throw new UnableToSaveRecordException();
            }
            throw new InvalidParameterException("Bad Request. Unable to create account.");
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
                    throw new IncorrectPinException("id");
                }
                if(!errors.Any()) { throw new DataValidationException(errors); }

                //update account
                account.Pin = pin;
                var updateAccount = _unitOfWork.Accounts.UpdateAsync(account);
                if (updateAccount != null)
                {
                    var result = await _unitOfWork.Save();
                    return result > 0 ? true: throw new UnableToSaveRecordException();
                }
                throw new InvalidParameterException("Bad Request. Unable to create account.");
            }           
            throw new BadKeyException("acount", id);
        }
        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var response = await _unitOfWork.Accounts.GetAllAsync();
            if (response is null)
            {
                throw new MysqlDataNullException();
            }
            else if(!response.Any())
            {

                throw new NoRecordsFoundException("Library Account");
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
                    throw new MysqlDataNullException();
                }
                else if (!response.Any())
                {

                    throw new NoRecordsFoundException("${typename} Accounts");
                }
                else
                {
                    IEnumerable<AccountDTO> accountDtoList = _mapper.Map<Account[], IEnumerable<AccountDTO>>(response.ToArray());
                    return accountDtoList;
                }

            }
            else
            {

                throw new InvalidParameterException("$Bad Request Error.{typename} is not a valid account type");
            }
            

        }

        public async Task<IEnumerable<LoanDTO>> GetAllCurrentLoans()
        {
            var response = await _unitOfWork.Loans.GetAllWhereAsync(x => x.IsComplete == false);
            if (response is null)
            {
                throw new MysqlDataNullException();
            }
            else if (!response.Any())
            {

                throw new NoRecordsFoundException("Loan");
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
                throw new MysqlDataNullException();
            }
            else if (!response.Any())
            {

                throw new NoRecordsFoundException("Loan");
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
                throw new MysqlDataNullException();
            }
            else if (!response.Any())
            {

                throw new NoRecordsFoundException("Loan");
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
                throw new NoRecordsFoundException($"{accountID} loans"); 
            }
            return accountLoans.Where(x => x.IsComplete == false);             
        }

        public async Task<IEnumerable<LoanDTO>> GetAccountOverdueLoans(string accountID)
        {
            var accountLoans = await GetLoanHistory(accountID);
            if (!accountLoans.Any())
            {
                throw new NoRecordsFoundException($"{accountID} loans");
            }
            return accountLoans.Where(x => x.Status == LoanStatus.Overdue);
        }

        
    }
}
