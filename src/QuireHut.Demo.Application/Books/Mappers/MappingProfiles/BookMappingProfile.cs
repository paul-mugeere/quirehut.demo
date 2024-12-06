using AutoMapper;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Mappers.MappingProfiles;

public class BookMappingProfile:Profile
{
    public BookMappingProfile()
    {
        CreateMap<Edition, EditionDto>()
            .ForMember(x=>x.EditionId, y=>y.MapFrom(x=>x.Id.Value))
            .ForMember(x=>x.ISBN, y=>y.MapFrom(x=>x.ISBN.Value));
        
        CreateMap<Dimensions, DimensionsDto>();
        CreateMap<Publisher, PublisherDto>();
        
        CreateMap<Person, BookAuthorDto>()
            .ForMember(x=>x.Fullname,y=>y.MapFrom(n=>n.Fullname.ToString()))
            .ForMember(x=>x.Id,y=>y.MapFrom(n=>n.Id.Value));
        CreateMap<Book, BookDto>()
            .ForMember(x=>x.Authors, y=>y.Ignore())
            .ForMember(x=>x.Title, y=>y.MapFrom(n=>n.Title.Value))
            .ForMember(x=>x.BookId,y=>y.MapFrom(n=>n.Id.Value));
        CreateMap<Book, BookDetailsDto>()
            .ForMember(x=>x.Authors, y=>y.Ignore())
            .ForMember(x=>x.BookId, y=>y.MapFrom(x=>x.Id.Value))
            .ForMember(x=>x.Title, y=>y.MapFrom(x=>x.Title.Value));
        
    }
}