using AutoMapper;
using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Mapper
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<FineDTO, Fine>()
               .ReverseMap();

            CreateMap<LoanDTO, Loan>()
             .ForMember(dest => dest.Key, opt => opt.Ignore())
             .ForMember(dest => dest.Account, opt => opt.Ignore())
             .ForMember(dest =>dest.BookCopy, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<ReservationDTO, Reservation>()
             .ForMember(dest => dest.Key, opt => opt.Ignore())
             .ForPath(dest => dest.Account, opt => opt.Ignore())
             .ForMember(dest => dest.BookCopy, opt => opt.Ignore())
             .ReverseMap();
        }
    }
}
