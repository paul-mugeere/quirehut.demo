using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBookDetailsQuery(Guid BookId):IRequest<Result<BookQueryResult>>;