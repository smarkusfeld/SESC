using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.UnitTests.Mocks
{
    internal class MockIAccountRepository
    {
        public static Mock<IAccountRepository> GetMock()
        {
            var mock = new Mock<IAccountRepository>();
            var accounts = new List<Account>()
        {
            new Account()
            {
                ID=1,
                StudentID="c1234567",
                HasOutstandingBalance=false,
                
            },
             new Account()
            {
                ID=2,
                StudentID="c765321",
                HasOutstandingBalance=false,
            },
             new Account()
            {
                ID=3,
                StudentID="c1122334",
                HasOutstandingBalance=false,
            },
        };
            // Set up
            mock.Setup(m => m.FindAll()).Returns(() => accounts);
            mock.Setup(m => m.Find(It.IsAny<int>()))
                .Returns((int id) => accounts.FirstOrDefault(x => x.ID == id));
            mock.Setup(m => m.FindWhere(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns((string id) => accounts.Single(x => x.StudentID == id));
            mock.Setup(m => m.Create(It.IsAny<Account>()))
            .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Account>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<Account>()))
               .Callback(() => { return; });
            return mock;


        }
    }
}
