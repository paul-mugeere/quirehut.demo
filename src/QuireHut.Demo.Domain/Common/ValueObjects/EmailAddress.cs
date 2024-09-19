using System.Text.RegularExpressions;

namespace QuireHut.Demo.Domain;

public readonly record struct EmailAddress
{
    public string Value { get; } = string.Empty;
    public static EmailAddress Empty { get; } = new();


    public EmailAddress(string value)
    {
        if (!string.IsNullOrWhiteSpace(value) && !IsValidEmail(value))
        {
            throw new InvalidEmailException("Email provided is incorrect.");
        }
        Value = value;
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    public override string ToString()
    {
        return Value;
    }
}