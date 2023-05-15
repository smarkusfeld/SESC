using FinanceService.Application.DTOs;
using FinanceService.Domain.Entities;
using AutoMapper;

namespace FinanceService.Application.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
            //.ForMember(dest => dest.Invoices, opt => opt.Ignore())
            //.ForMember(dest => dest.Payments, opt => opt.Ignore());
            .ForMember(dest => dest.HasOutstandingBalance, opt => opt.Ignore());
            CreateMap<AccountDTO, Account>()
              .ForMember(dest => dest.Invoices, opt => opt.Ignore())
              .ForMember(dest => dest.Payments, opt => opt.Ignore());

        }
    }
}
