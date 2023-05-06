using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;

namespace FinanceMicroservice.Application.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
            CreateMap<AccountDTO, Account>()
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
