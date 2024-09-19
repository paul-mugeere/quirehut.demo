public readonly record struct Address(string Country, string Street, string City, string State, string PostalCode){
    public static Address Empty{get;} = default;
}