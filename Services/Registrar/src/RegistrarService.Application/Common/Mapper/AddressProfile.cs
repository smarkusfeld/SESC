using AutoMapper;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RegistrarService.Application.Common.Mapper
{
    public class AddressProfile : Profile
    {
        /// <summary>
        /// Automapper maps for address entity 
        /// </summary>
        public AddressProfile()
        {
            CreateMap<AddressDTO, Address>()
                    .ReverseMap()
                    .ForAllMembers(opts =>
                    {
                        opts.AllowNull();
                        opts.Condition((src, dest, srcMember) => srcMember != null);
                    });
        }
    }
}
