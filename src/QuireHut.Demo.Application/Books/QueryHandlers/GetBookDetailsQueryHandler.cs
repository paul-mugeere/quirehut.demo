using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookDetailsQueryHandler(
    IBookQueryService bookQueryService,
    IBookMapper bookMapper)
    : IRequestHandler<GetBookDetailsQuery, Result<BookDetailsDto>>
{

    public async Task<Result<BookDetailsDto>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookByIdAsync(new BookId(request.BookId));
            return Result<BookDetailsDto>.Success(bookMapper.MapToBookDetailsDto(result.book,result.authors));
        }
        catch (Exception e)
        {
            return Result<BookDetailsDto>.FromException(e);
        }
    }
}