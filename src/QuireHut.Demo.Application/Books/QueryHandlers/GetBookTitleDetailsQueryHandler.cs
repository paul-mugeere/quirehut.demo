using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookTitleDetailsQueryHandler(
    IBookTitleMapper mapper,
    IBookQueryService bookQueryService
    ):IRequestHandler<GetBookTitleDetailsQuery, Result<BookTitleDto>>
{
    public async Task<Result<BookTitleDto>> Handle(GetBookTitleDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookByIdAsync(new BookId(request.BookId));
            if (result.book ==null)
                return Result<BookTitleDto>.Success($"Book with id {request.BookId} not found");
            
            var bookEdition = result.book.Editions.FirstOrDefault(x=>x.Id.Value == request.EditionId);
            if (bookEdition == null)
                return Result<BookTitleDto>.Success($"Edition with id {request.EditionId} not found");
            
            return Result<BookTitleDto>.Success(mapper.MapToBookTitleDto(result.book, bookEdition, result.authors));
        }
        catch (Exception e)
        {
            return Result<BookTitleDto>.Failure(e.Message);
        }
    }
}