using System.Net.Mail;

namespace LinguaCommunity.Domain.Models.Users;

public sealed record Email
{
    public Email(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        var normalizedValue = value.Trim().ToLowerInvariant();

        if (!IsValid(normalizedValue))
            throw new ArgumentException("The email address is invalid.", nameof(value));

        Value = normalizedValue;
    }

    public string Value { get; }

    public static implicit operator string(Email email) => email.Value;

    public override string ToString() => Value;

    private static bool IsValid(string value)
    {
        try
        {
            var address = new MailAddress(value);

            return address.Address == value;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}