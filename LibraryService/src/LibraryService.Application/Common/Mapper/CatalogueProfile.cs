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
    public class CatalogueProfile : Profile
    {
        public CatalogueProfile()
        {
            // CreateMap<BaseEntity, BaseModel>();
            //CreateMap<BaseAuditableEntity, BaseAuditableModel>();

            // CreateMap<BaseModel, BaseEntity>()
            //     .ForMember(dest => dest.DomainEvents, act => act.Ignore());
            //CreateMap<BaseAuditableModel, BaseAuditableEntity>()
            //.IncludeBase<BaseModel, BaseEntity>();

            //CreateMap<AuthorDTO, Author>();
            // CreateMap<PublisherDTO, Publisher>();
            //CreateMap<SubjectDTO, Subject>();

            CreateMap<SubjectDTO, Subject>()
                .ForPath(dest => dest.Key, opt => opt.Ignore())
                .ForPath(dest => dest.BookSubjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PublisherDTO, Publisher>()
                .ForPath(dest => dest.Key, opt => opt.Ignore())
                .ForPath(dest => dest.BookPublishers, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<AuthorDTO, Author>()
                .ForPath(dest => dest.Key, opt => opt.Ignore())
                .ForPath(dest => dest.BookAuthors, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BookIdentifierDTO, BookIdentifier>()
                .ReverseMap()
                .ForPath(dest => dest.isbn_10, opt => opt.Ignore())
                .ForPath(dest => dest.isbn_13, opt => opt.Ignore())
                .ForPath(dest => dest.lccn, opt => opt.Ignore())
                .ForPath(dest => dest.oclc, opt => opt.Ignore())
                .ForPath(dest => dest.openlibrary, opt => opt.Ignore());

            CreateMap<BookClassificationDTO, BookClassification>()
               .ReverseMap()
               .ForPath(dest => dest.dewey_decimal_class, opt => opt.Ignore())
               .ForPath(dest => dest.lc_classifications, opt => opt.Ignore());


            CreateMap<NewBookRecordDTO, Book>()
                .ForMember(dest => dest.Key, opt => opt.Ignore())                
                .ForMember(dest => dest.BookCopies, opt => opt.Ignore())
                .ForMember(dest => dest.BookSubjects, opt => opt.Ignore())
                .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
                .ForMember(dest => dest.BookPublishers, opt => opt.Ignore());

            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Key, opt => opt.Ignore())
                .ForMember(dest => dest.BookCopies, opt => opt.Ignore())
                .ForMember(dest => dest.BookSubjects, opt => opt.Ignore())
                .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
                .ForMember(dest => dest.BookPublishers, opt => opt.Ignore())
                .ForMember(dest => dest.Subjects, opt => opt.Ignore())
                .ForMember(dest => dest.Authors, opt => opt.Ignore())
                .ForMember(dest => dest.Publishers, opt => opt.Ignore())
                .ReverseMap();


            //CreateMap<BookAuthor, AuthorDTO>();
            //CreateMap<BookSubject, SubjectDTO>();
            //CreateMap<BookPublisher, PublisherDTO>();

        }
        
    }
}
