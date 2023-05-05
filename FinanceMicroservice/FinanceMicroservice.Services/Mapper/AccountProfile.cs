using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;


namespace FinanceMicroservice.Application.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();
        }
    }
}
