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
    public class EnumConverter : ITypeConverter<string, Enumeration>
    {

        public Enumeration Convert(string source, Enumeration destination, ResolutionContext context)
        {
            return Enumeration.FromName<Enumeration>(source);
        }
    }
    
        

}
