using AutoMapper;
using LibraryService.Application.Models;
using LibraryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Mapper
{
    public class BaseEntityModelProfile : Profile
    {
        public BaseEntityModelProfile() 
        {
           

            CreateMap<BaseModel, BaseEntity>()
                .ForMember(dest=>dest.Key, opt=> opt.Ignore())
                .ReverseMap();
            CreateMap<BaseAuditableModel, BaseAuditableEntity>()
                .IncludeBase<BaseModel, BaseEntity>()
                .ReverseMap();

        }

    }
}
