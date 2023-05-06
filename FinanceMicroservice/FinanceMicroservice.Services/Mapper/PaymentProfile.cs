using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;

namespace FinanceMicroservice.Application.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<string, PaymentStatus>().ConvertUsing(x => Enumeration.FromName<PaymentStatus>(x));
            CreateMap<PaymentStatus, string>().ConvertUsing(x => x.Name);
            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();
        }
    }
}