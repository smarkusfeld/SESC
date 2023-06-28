using LibraryService.Application.Models;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Entities;
using AutoMapper;
using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Common.Exceptions;

namespace LibraryService.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFeeService _feeService;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper, IFeeService feeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _feeService = feeService;
        }

        public async Task<LoanDTO> CreateLoan(string id, string isbn, int pin, int duration = 14)
        {
            //check student account and pin
            var account = await ValidatePin(id, pin);
            //get book record
            var bookRecord = await _unitOfWork.Books.GetAsync(isbn);
            if (bookRecord == null) { throw new KeyNotFoundException($"No match for {isbn}"); }

            //checkout book
            var bookCopyId = await CheckOutBook(bookRecord);
            //create new loan for default loan period 
            DateTime dueDate = DateTime.Now.AddDays(duration);
            Loan loan = new Loan(dueDate, isbn, bookRecord.Title, account.AccountId, bookCopyId);

            //add loan
            var reponse = await _unitOfWork.Loans.AddAsync(loan);
            if (reponse != null)
            {
                LoanDTO dto = _mapper.Map<LoanDTO>(reponse);
                var result = await _unitOfWork.Save();
                return result > 0 ? _mapper.Map<LoanDTO>(dto) : throw new MySQLNullException();
            }
            throw new BadRequestException("Unable to create loan.");
        }

        public Task<ReservationDTO> CreateReservation(string id, string isbn, int pin)
        {
            throw new System.NotImplementedException();
        }
        public Task<LoanDTO> RenewBook(string id, string isbn, int pin)
        {
            throw new System.NotImplementedException();
        }
        public async Task<LoanDTO> ReturnBook(string id, string isbn, int pin)
        {
            //validate account
            var account = await ValidatePin(id, pin);
            //return book
            var bookCopyId = await ReturnBook(isbn);
            //find loan
            var loanList = await _unitOfWork.Loans.GetAllWhereAsync(x => x.Id.Equals(account.AccountId) && x.BookCopyId == bookCopyId);
            if (loanList.Any())
            {
                var loan = loanList.First(x => x.IsComplete == false);
                if (loan.Status == LoanStatus.Overdue)
                {
                    int overdueby = DateTime.Now.Subtract(loan.DueDate).Days;
                    Decimal amount = (decimal)(overdueby * .20);
                    loan.AddFine(DateTime.Now, amount);

                }
                loan.IsComplete = true;
                loan.DateReturned = DateTime.Now;
                //update loan
                var reponse = await _unitOfWork.Loans.UpdateAsync(loan);
                if (reponse != null)
                {
                    var result = await _unitOfWork.Save();
                    var dto = _mapper.Map<LoanDTO>(reponse);
                    return result > 0 ? dto : throw new MySQLNullException();
                }
                throw new BadRequestException("Unable to update loan.");
            }
            throw new BadRequestException($"No Outstanding loands for account: {id} and isbn: {isbn}.");
        }


        private async Task<int> ReturnBook(string isbn)
        {
            var bookRecord = await _unitOfWork.Books.GetAsync(isbn) ?? throw new KeyNotFoundException($"No match for {isbn}");
            var copy = bookRecord.BookCopies.First(x => x.Status == BookCopyStatus.OnLoan);
            if (copy == null) { throw new NotFoundException($"No Matching Loans for {isbn}"); }
            bookRecord.ReturnBookCopy(copy.Id);
            var checkIn = await _unitOfWork.Books.UpdateCopiesAsync(bookRecord);
            if (checkIn)
            {
                var save = await _unitOfWork.Save();
                return save > 0 ? copy.Id : throw new MySQLNullException();
            }
            throw new BadRequestException($"Unable to return {isbn}");
        }
        /// <summary>
        /// Checkout Book
        /// </summary>
        /// <param name="bookRecord"></param>
        /// <returns>Returns Book Copy ID</returns>
        /// <exception cref="NoAvailableBookCopiesException"></exception>
        /// <exception cref="InvalidParameterException"></exception>
        private async Task<int> CheckOutBook(Book bookRecord)
        {
            //update bookcopy entity
            var bookCopyID = bookRecord.LoanBookCopy();
            if (bookCopyID == 0) { throw new BadRequestException($"No Available Copies of {bookRecord.Title}, {bookRecord.ISBN} for Loan"); }
            //checkout bookcopy
            var checkout = await _unitOfWork.Books.UpdateCopiesAsync(bookRecord);
            if (checkout)
            {
                var save = await _unitOfWork.Save();
                return save > 0 ? bookCopyID : throw new MySQLNullException();
            }
            throw new BadRequestException("Unable to create account.");
        }

        private async Task<AccountDTO> ValidatePin(string id, int pin)
        {
            List<string> errors = new List<string>();//check if account exists
            var account = await _unitOfWork.Accounts.GetAsync(id);

            if (account != null)
            {
                //validate request
                if (pin.ToString().Length <= 6 || pin.ToString().Length >= 12)
                {
                    errors.Add("New Pin must be between 6 and 12 digits");
                }
                //if (int.TryParse(pin, out int pin))
                //{
                // errors.Add($"Incorrect format for {pinString}. Pin number must be numerical and between 6-12 digits");
                // }
                if (account.Pin != pin)
                {
                    throw new BadRequestException("Incorrect Pin Number");
                }
                if (!errors.Any()) { throw new BadRequestException("Invalid Request", errors); }


                AccountDTO dto = _mapper.Map<AccountDTO>(account);
                return dto;
            }
            throw new KeyNotFoundException($"No account found for id {id}");
        }
        public async Task<IEnumerable<LoanDTO>> GetAllOverdueLoans()
        {
            var all = await _unitOfWork.Loans.GetAllOverdueAsync();
            return _mapper.Map<IEnumerable<Loan>, IEnumerable<LoanDTO>>(all);

        }
        public async Task<IEnumerable<LoanDTO>> GetAllActiveLoans()
        {
            var all = await _unitOfWork.Loans.GetAllOverdueAsync();
            return _mapper.Map<IEnumerable<Loan>, IEnumerable<LoanDTO>>(all);

        }

        public Task<LoanDTO> IssueFine(LoanDTO loandto)
        {
            throw new System.NotImplementedException();
        }
    }
}
