using FluentAssertions;

namespace Library.Demo.Domain.Tests;

public class GivenPerson
{
    [Fact]
    public void Given_Person_AddAddresses_Should_Add_New_Address()
    {
        var person = Person.CreateNew("test-firstname", "test-lastname");
        var addresses = new List<Address> {
            Address.CreateNew(person.Id, "test-country", "test-city", "test-state", "test-postcode", "test-street")
             };
        person.AddAddresses(addresses);
        person.Addresses.ToList().Should().HaveCount(1);

    }
}
