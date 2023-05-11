using FinanceService.Application.DTOs;
using FinanceService.Domain.Entities;
using AutoMapper;

namespace FinanceService.Application.Mapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<Invoice, InvoiceDTO>();
        }
    }
}
