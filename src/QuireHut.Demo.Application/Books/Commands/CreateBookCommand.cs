﻿using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.Enums;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Application.Books.Commands;

public record CreateBookCommand : IRequest<Result<Guid>>
{
    public string Title { get; init; } = string.Empty;
    public string Subject { get; init; } = string.Empty;
    public List<Guid> AuthorIds { get; init; } 
    public List<EditionDto> Editions { get; init; }
}

public static class CreateBookCommandMapper{
    public static Book MapToBook(this CreateBookCommand command){
        return Book.CreateNew(
            new Title(command.Title),
            new BookDescription(command.Subject),
            command.Editions.Select(x=>
                Edition.CreateNew(
                    new ISBN(x.ISBN),
                    (Format)x.Format,
                    x.Language,
                    new Publisher(x.Publisher?.Name),
                    x.PublicationDate,
                    new Dimensions(x.Dimensions?.Height, x.Dimensions?.Width, x.Dimensions?.Depth),
                    x.Price,
                    x.NumberOfPages,
                    (EditionStatus)x.Status
                    )
                ).ToList(), 
            command.AuthorIds.Select(x=>new PersonId(x)).ToList());
    }
}
