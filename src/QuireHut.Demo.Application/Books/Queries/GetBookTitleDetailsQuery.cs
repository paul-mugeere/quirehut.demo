using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBookTitleDetailsQuery(Guid EditionId):IRequest<Result<BookTitleWithAuthorsQueryResult>>;