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
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<string, Enumeration>().ConvertUsing(new EnumTypeConverter());
            CreateMap<Enumeration, string>().ConvertUsing(x => x.ToString());
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<Invoice, InvoiceDTO>(); 
        }
    }
}
