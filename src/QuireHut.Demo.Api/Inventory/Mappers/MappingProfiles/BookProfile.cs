using AutoMapper;
using QuireHut.Demo.Api.Inventory.Requests;
using QuireHut.Demo.Api.Inventory.Responses;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Inventory.Mappers.MappingProfiles;

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
        CreateMap<CreateBookRequest, CreateBookCommand>();
        CreateMap<CreateEditionRequest, EditionDto>();
        CreateMap<BookTitleDto, BookTitle>();
    }
}