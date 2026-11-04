namespace LinguaCommunity.Domain.Models.Users;

public sealed record Name
{
    public const int MaxLength = 100;

    public Name(string? firstName, string? lastName)
    {
        FirstName = Normalize(firstName, nameof(firstName));
        LastName = Normalize(lastName, nameof(lastName));
    }

    public string? FirstName { get; }
    public string? LastName { get; }

    private static string? Normalize(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        value = value.Trim();

        if (value.Length > MaxLength)
            throw new ArgumentException($"Name cannot exceed {MaxLength} characters.",parameterName);

        return value;
    }
}