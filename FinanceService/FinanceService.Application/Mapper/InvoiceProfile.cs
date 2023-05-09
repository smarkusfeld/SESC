using FinanceService.Application.DTOs;
using FinanceService.Domain.Entities;
using AutoMapper;

namespace FinanceService.Application.Mapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
        CreateMap<Invoice, InvoiceDTO>()
            .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
        CreateMap<Invoice, InvoiceDTO>()
            .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
