namespace QuireHut.Demo.Domain.Common.ValueObjects;

public readonly record struct Address(string Country, string Street, string City, string State, string PostalCode){
    public static Address Empty{get;} = default;
    public override string ToString() => $"{Street}, {City}, {State} {PostalCode}, {Country}";
}