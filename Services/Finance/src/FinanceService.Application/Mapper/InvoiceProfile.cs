﻿using FinanceService.Application.DTOs;
using FinanceService.Domain.Entities;
using AutoMapper;

namespace FinanceService.Application.Mapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {


            CreateMap<Invoice, InvoiceDTO>()      
             .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID));
            CreateMap<InvoiceDTO, Invoice>()
             .ForMember(dest => dest.Payments, opt => opt.Ignore())
             .ForMember(dest => dest.Account, opt => opt.Ignore());
        }
    }
}
