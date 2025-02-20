using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Requests;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.DTOs.Books;
using Dimensions = QuireHut.Demo.Application.Books.DTOs.Books.Dimensions;
using Publisher = QuireHut.Demo.Application.Books.DTOs.Books.Publisher;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookProfile: Profile
{
    public BookProfile()
    {
        CreateMap<EditionItem, Edition>();
        CreateMap<Dimensions, Models.Dimensions>().ReverseMap();
        CreateMap<Publisher, Models.Publisher>().ReverseMap();
        CreateMap<Author, BookAuthor>();
        CreateMap<BookQueryResult, Book>();
        CreateMap<BookQueryResult, BookDetails>();
        CreateMap<PostBookRequest, CreateBookCommand>();
        CreateMap<PostBookEdition, EditionItem>();
        CreateMap<BookTitleWithAuthorsQueryResult, BookTitle>();
    }
}