using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBookEditionQuery(BookId BookId,EditionId EditionId):IRequest<Result<BookItemDetails>>;