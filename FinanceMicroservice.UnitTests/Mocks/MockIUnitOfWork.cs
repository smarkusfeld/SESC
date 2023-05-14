using FinanceService.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.UnitTests.Mocks
{
    public class MockIUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();
            var accountRepoMock = MockIAccountRepository.GetMock();
            mock.Setup(m => m.Accounts).Returns(() => accountRepoMock.Object);
            mock.Setup(m => m.Invoices).Returns(() => new Mock<IInvoiceRepository>().Object);
            mock.Setup(m => m.Payments).Returns(() => new Mock<IPaymentRepository>().Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });
            return mock;
        }
        
    }
}
