using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Application.Books.Queries.ReadModels;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookTitleProfile : Profile
{

    public BookTitleProfile()
    {
        CreateMap<BookTitleWithAuthorsQueryResult, BookTitle>();
        CreateMap<BookTitleWithAuthorsQueryResult, BookTitleDetails>()
            .ForMember(dest=>dest.PublicationYear, src =>
            {
                src.PreCondition(dto => dto.PublicationYear.HasValue);
                src.MapFrom(dto => dto.PublicationYear.Value);
            });
        CreateMap<Author, BookTitleAuthor>();
    }
}