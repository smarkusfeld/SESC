using AutoMapper;
using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {


            CreateMap<AccountDTO, Account>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Loans, opt => opt.Ignore())
              .ForMember(dest => dest.Reservations, opt => opt.Ignore())
              .ForMember(dest => dest.OverdueLoans, opt => opt.Ignore())
              .ForMember(dest => dest.OverdueLoanTotal, opt => opt.Ignore())
              .ForMember(dest => dest.ActiveLoans, opt => opt.Ignore())
              .ForMember(dest => dest.ActiveLoanTotal, opt => opt.Ignore())
              .ReverseMap();




        }
    }
}
