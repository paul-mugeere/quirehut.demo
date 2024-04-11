namespace Library.Demo.Domain;

public abstract class UserAccount{
    public string? Password { get; private set; }
    public UserAccountStatus Status { get; private set; }
    public Person? Person { get; private set; }
    public LibraryCard? LibraryCard { get; private set; }

    public bool ResetPassword(){
        throw new NotImplementedException();
    }
}

public class LibraryMember{}
public class Librarian{}
