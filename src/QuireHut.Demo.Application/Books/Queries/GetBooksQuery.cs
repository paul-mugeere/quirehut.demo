using MediatR;
using QuireHut.Demo.Application.Books.DTOs;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBooksQuery : IRequest<Result<BookItems>>
{
}