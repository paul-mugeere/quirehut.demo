using FluentAssertions;

namespace Library.Demo.Domain.Tests;

public class EmailAddressTests
{
    [Fact]
    public void Given_Email_Is_Not_Valid_Should_Throw_InvalidEmailException(){
        
        Action action= () => new EmailAddress("invalid_email");
        action.Should().Throw<InvalidEmailException>();
    }

    [Fact]
    public void Given_Email_Is_Valid_Should_Not_Throw_InvalidEmailException(){
        
        Action action= () => new EmailAddress("test@test.com");
        action.Should().NotThrow<InvalidEmailException>();
    }

    
    [Fact]
    public void Given_Email_Is_EmptyString_Should_Not_Throw_InvalidEmailException(){
        
        Action action= () => new EmailAddress("");
        action.Should().NotThrow<InvalidEmailException>();
    }

}