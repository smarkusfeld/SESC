using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Mapper;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.UnitTests
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _Mapper;
        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<InvoiceProfile>();
                cfg.AddProfile<PaymentProfile>();

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
        [InlineData(typeof(InvoiceDTO), typeof(Invoice))]
        [InlineData(typeof(Invoice), typeof(InvoiceDTO))]
        public void InvoiceMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(PaymentDTO), typeof(Payment))]
        [InlineData(typeof(Payment), typeof(PaymentDTO))]
        public void PaymentMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
    }
}
