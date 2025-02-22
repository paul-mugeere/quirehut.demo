using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using Author = QuireHut.Demo.Api.Models.Author;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookWithAuthorsQueryResult, Book>();
        CreateMap<BookWithAuthorsQueryResult, BookDetails>()
            .ForMember(dest=>dest.PublicationYear, src =>
            {
                src.PreCondition(dto => dto.PublicationYear.HasValue);
                src.MapFrom(dto => dto.PublicationYear.Value);
            });
        CreateMap<Application.Books.Queries.ReadModels.Author, Author>();
    }
}