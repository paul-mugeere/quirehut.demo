namespace Library.Demo.Domain;

public abstract class UserAccount{
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserAccountStatus Status { get; private set; }
    public Person? Person { get; private set; }
    public LibraryCard? LibraryCard { get; private set; }

    public bool ResetPassword(){
        throw new NotImplementedException();
    }
}

public class LibraryMember{}
public class LibraryStaff{
    public void AddBookItem(Book bookItem){}
    public void BlockMember(LibraryMember member){}
    public void UnBlockMember(LibraryMember member){}
}
