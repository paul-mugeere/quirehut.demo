using QuireHut.Demo.Api.Contracts.Responses;

public static class LoremIpsum{
    public static GetBooksResponse BooksResponse => new GetBooksResponse
    {
        Books = new List<BookResponse>
        {
            new BookResponse() with { Id = Guid.NewGuid(), Title = "Book 1", Author = "Author 1", AverageRating=3, Description="Loremu Ipsum", Price=300, PublicationDate= DateTime.Now.AddYears(-13) },
            new BookResponse() with { Id = Guid.NewGuid(), Title = "Book 2", Author = "Author 2", AverageRating=4, Description="Loremu Ipsum", Price=300, PublicationDate= DateTime.Now.AddYears(-13) },
            new BookResponse() with { Id = Guid.NewGuid(), Title = "Book 3", Author = "Author 3", AverageRating=5, Description="Loremu Ipsum", Price=300, PublicationDate= DateTime.Now.AddYears(-13) },
            new BookResponse() with { Id = Guid.NewGuid(), Title = "Book 4", Author = "Author 4", AverageRating=2, Description="Loremu Ipsum", Price=300, PublicationDate= DateTime.Now.AddYears(-13) },
            new BookResponse() with { Id = Guid.NewGuid(), Title = "Book 5", Author = "Author 5", AverageRating=1, Description="Loremu Ipsum", Price=300, PublicationDate= DateTime.Now.AddYears(-13) }
        }
    };
}