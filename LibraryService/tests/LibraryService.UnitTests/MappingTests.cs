using AutoMapper;
using LibraryService.Application.Common.Mapper;
using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.UnitTests
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _Mapper;
        public IMapper mapper { get { return _Mapper; } }
        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CatalogueProfile>();
                cfg.AddProfile<LoanProfile>();

            });
            _Mapper = _configuration.CreateMapper();
        }
        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        [Theory]
        [InlineData(typeof(AccountDTO), typeof(Account))]
        [InlineData(typeof(Account), typeof(AccountDTO))]
        public void AccountMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(LoanDTO), typeof(Loan))]
        [InlineData(typeof(Loan), typeof(LoanDTO))]
        public void LoanMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }

        [Theory]
        [InlineData(typeof(FineDTO), typeof(Fine))]
        [InlineData(typeof(Fine), typeof(FineDTO))]
        public void FineMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(ReservationDTO), typeof(Reservation))]
        [InlineData(typeof(Reservation), typeof(ReservationDTO))]
        public void ReservationMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
    }

}
