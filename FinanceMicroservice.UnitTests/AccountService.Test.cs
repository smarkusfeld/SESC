using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.API.Controllers;
using FinanceService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using FinanceService.Application.Services;


namespace FinanceMicroservice.UnitTests
{
    public class AccountService
    {
        private readonly Mock<IUnitOfWork> unitOfWork;
        public AccountService()
        {
            unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetAccounts_AccountList()
        {
        }

        private List<AccountDTO> GetaccoutDTOList()
        {
            List<AccountDTO> accoutDTOList = new List<AccountDTO>
        {
            new AccountDTO
            {
                ID=1,
                StudentID="c1234567",
                HasOutstandingBalance=false,
            },
             new AccountDTO
            {
                ID=2,
                StudentID="c765321",
                HasOutstandingBalance=false,
            },
             new AccountDTO
            {
                ID=3,
                StudentID="c1122334",
                HasOutstandingBalance=false,
            },
        };
            return accoutDTOList;
        }
    }



    
}
