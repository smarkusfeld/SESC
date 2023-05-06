using AutoMapper;
using FinanceMicroservice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Mapper
{
    internal class EnumTypeConverter : ITypeConverter<string, Enumeration>
    {

        public Enumeration Convert(string source, Enumeration destination, ResolutionContext context)
        {
            return Enumeration.FromName<Enumeration>(source);
        }
       
    }
    
}
