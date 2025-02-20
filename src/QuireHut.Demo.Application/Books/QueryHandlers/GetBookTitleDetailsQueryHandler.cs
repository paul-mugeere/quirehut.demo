using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookTitleDetailsQueryHandler(
    IBookQueryService bookQueryService
    ):IRequestHandler<GetBookTitleDetailsQuery, Result<BookTitleWithAuthorsQueryResult>>
{
    public async Task<Result<BookTitleWithAuthorsQueryResult>> Handle(GetBookTitleDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookTitleByEditionIdAsync(new EditionId(request.EditionId));
            if (result ==null)
                return Result<BookTitleWithAuthorsQueryResult>.Success($"Edition of id {request.EditionId} not found");
            
            return Result<BookTitleWithAuthorsQueryResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookTitleWithAuthorsQueryResult>.Failure(e.Message);
        }
    }
}