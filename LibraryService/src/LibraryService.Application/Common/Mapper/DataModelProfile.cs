using AutoMapper;
using LibraryService.Domain.Common;
using LibraryService.Domain.DataModels;
using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Mapper
{
    public class DataModelProfile : Profile
    {
        public DataModelProfile()
        {
            CreateMap<BaseEntity, BaseModel>();
            CreateMap<BaseAuditableEntity, BaseAuditableModel>();

            CreateMap<BaseModel, BaseEntity>()
                .ForMember(dest => dest.DomainEvents, act => act.Ignore());
            CreateMap<BaseAuditableModel, BaseAuditableEntity>()
                .IncludeBase<BaseModel, BaseEntity>();

            CreateMap<Author, AuthorModel>();
                
        }
        
    }
}
