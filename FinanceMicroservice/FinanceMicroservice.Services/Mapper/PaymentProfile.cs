using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;

namespace FinanceMicroservice.Application.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();
        }
    }
}