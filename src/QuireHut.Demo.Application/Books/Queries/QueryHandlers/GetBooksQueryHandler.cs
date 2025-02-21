using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBooksQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBooksQuery, Result<BookCollectionQueryResult>>
{
    public async Task<Result<BookCollectionQueryResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetAllBooks();
            return Result<BookCollectionQueryResult>.Success(BookCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookCollectionQueryResult>.FromException(e);
        }
    }
}