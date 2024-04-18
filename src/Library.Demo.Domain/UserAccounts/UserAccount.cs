namespace Library.Demo.Domain;

public abstract class UserAccount{
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserAccountStatus Status { get; private set; }
    //public LibraryCard? LibraryCard { get; private set; }

    public bool ResetPassword(){
        throw new NotImplementedException();
    }

}
