namespace Library.Demo.Domain;

public record Book(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    DateTime? PublishedOn,
    string Language,
    int NumberOfPages,
    BookFormat Format,
    Author Author
);
