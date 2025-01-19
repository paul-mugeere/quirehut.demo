using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookTitleProfile : Profile
{

    public BookTitleProfile()
    {
        CreateMap<BookTitleDto, BookTitle>();
        CreateMap<BookTitleDto, BookTitleDetails>()
            .ForMember(dest=>dest.PublicationDate, src =>
            {
                src.PreCondition(dto => dto.PublicationDate.HasValue);
                src.MapFrom(dto => dto.PublicationDate.Value.Year);
            });
        CreateMap<BookAuthorDto, BookTitleAuthor>();
    }
}