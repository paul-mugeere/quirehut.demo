using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookTitlesQueryHandler(
    IBookTitleMapper mapper,
    IBookQueryService bookQueryService)
    : IRequestHandler<GetBookTitlesQuery, Result<BookTitleCollectionDto>>
{

    public async Task<Result<BookTitleCollectionDto>> Handle(GetBookTitlesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBooksAsync().ConfigureAwait(false);
            var result = mapper.MapToBookTitleDtos(bookTitles.books, bookTitles.authors);
            return Result<BookTitleCollectionDto>.Success(BookTitleCollectionDto.CreateNew(result));
        }
        catch (Exception e)
        {
            return Result<BookTitleCollectionDto>.Failure(e.Message);
        }
        
    }
}