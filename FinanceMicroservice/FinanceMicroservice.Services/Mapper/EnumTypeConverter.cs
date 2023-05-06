using AutoMapper;
using FinanceMicroservice.Domain.Enums;

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
