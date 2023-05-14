using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<string, Enumeration>().ConvertUsing<EnumConverter>();
            CreateMap<Enumeration, string>().ConvertUsing(e => e.ToString());
        }
        
    }
    
}
