using System.Text.RegularExpressions;

namespace LinguaCommunity.Domain.Models.Users;

public sealed partial record Nickname
{
    public const int MinLength = 3;
    public const int MaxLength = 30;

    [GeneratedRegex(@"^[\p{L}\p{N}_-]+$", RegexOptions.CultureInvariant)]
    private static partial Regex NicknameRegex();

    public string Value { get; }
    public string NormalizedValue { get; }

    public Nickname(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        value = value.Trim();

        if (value.Length is < MinLength or > MaxLength)
            throw new ArgumentException($"Nickname must contain between {MinLength} and {MaxLength} characters.", nameof(value));

        if (!NicknameRegex().IsMatch(value))
            throw new ArgumentException("Nickname contains invalid characters.", nameof(value));

        Value = value;
        NormalizedValue = value.ToUpperInvariant();
    }

    public override string ToString() => Value;
}