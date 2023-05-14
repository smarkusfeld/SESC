using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDTO, Payment>()
             .ForMember(dest => dest.Invoice, opt => opt.Ignore())
             .ForMember(dest => dest.Account, opt => opt.Ignore());
            CreateMap<Payment, PaymentDTO>()
             .ForMember(dest => dest.InvoiceID, opt => opt.MapFrom(src => src.Invoice.ID))
             .ForMember(dest => dest.AccountID, opt => opt.MapFrom(src => src.Account.ID));
        }
    }
}
