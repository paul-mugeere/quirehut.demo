using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBookTitleDetailsQuery(Guid EditionId):IRequest<Result<BookTitleWithAuthorsQueryResult>>;