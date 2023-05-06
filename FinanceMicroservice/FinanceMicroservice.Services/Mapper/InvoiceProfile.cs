using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;

namespace FinanceMicroservice.Application.Mapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<string, InvoiceType>().ConvertUsing(x => Enumeration.FromName<InvoiceType>(x));
            CreateMap<InvoiceType, string>().ConvertUsing(x => x.Name);
            CreateMap<string, InvoiceStatus>().ConvertUsing(x => Enumeration.FromName<InvoiceStatus>(x));
            CreateMap<InvoiceStatus, string>().ConvertUsing(x => x.Name);
            CreateMap<Invoice, InvoiceDTO>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
            CreateMap<Invoice, InvoiceDTO>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
