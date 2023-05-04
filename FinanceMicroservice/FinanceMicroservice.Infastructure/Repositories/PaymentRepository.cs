using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Application.Repositories;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Infastructure.Context;

namespace FinanceMicroservice.Infastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext dbContext) : base(dbContext)
        {

        }

    }
}
