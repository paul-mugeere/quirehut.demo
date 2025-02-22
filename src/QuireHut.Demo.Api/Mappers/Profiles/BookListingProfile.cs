using AutoMapper;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Requests;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using Author = QuireHut.Demo.Application.Books.Queries.ReadModels.Author;
using Dimensions = QuireHut.Demo.Application.Books.Queries.ReadModels.Dimensions;
using Publisher = QuireHut.Demo.Application.Books.Queries.ReadModels.Publisher;

namespace QuireHut.Demo.Api.Mappers.Profiles;

public class BookListingProfile: Profile
{
    public BookListingProfile()
    {
        CreateMap<EditionItem, Edition>();
        CreateMap<Dimensions, Models.Dimensions>().ReverseMap();
        CreateMap<Publisher, Models.Publisher>().ReverseMap();
        CreateMap<Author, Models.Author>();
        CreateMap<BookListingQueryResult, BookListing>();
        CreateMap<PostBookRequest, CreateBookCommand>();
        CreateMap<PostBookEdition, EditionItem>();
        CreateMap<BookWithAuthorsQueryResult, Book>();
    }
}