using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CreateMap<string, Enumeration>().ConvertUsing(new EnumTypeConverter());
            CreateMap<Enumeration, string>().ConvertUsing(x => x.ToString());
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
            CreateMap<AccountDTO, Account>()
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
