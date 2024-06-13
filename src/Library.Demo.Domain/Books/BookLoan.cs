namespace Library.Demo.Domain;

public record BookLoan{
    
    public DateTime? DateBorrowed { get; private set; } // this is an aspect of BookLoan
    public DateTime? DateDue { get; private set; } // this is an aspect of BookLoan
    
    public void CheckoutBookItem(PersonId personId, BookItemId bookItemId){
        throw new NotImplementedException();
    }

}

