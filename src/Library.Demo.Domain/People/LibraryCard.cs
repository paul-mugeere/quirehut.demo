namespace Library.Demo.Domain;

public class LibraryCard
{
    public string? CardNumber { get; private set; }
    public DateTime? DateIssued { get; private set; }
    public bool IsActive { get; private set; }
}
