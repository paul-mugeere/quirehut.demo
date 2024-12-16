using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Requests;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookProfile: Profile
{
    public BookProfile()
    {
        CreateMap<EditionDto, Edition>();
        CreateMap<DimensionsDto, Dimensions>().ReverseMap();
        CreateMap<PublisherDto, Publisher>().ReverseMap();
        CreateMap<BookAuthorDto, BookAuthor>();
        CreateMap<BookDto, Book>();
        CreateMap<BookDetailsDto, BookDetails>();
        CreateMap<CreateBook, CreateBookCommand>();
        CreateMap<CreateBookEdition, EditionDto>();
        CreateMap<BookTitleDto, BookTitle>();
    }
}