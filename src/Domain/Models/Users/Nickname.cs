using System.Text.RegularExpressions;

namespace LinguaCommunity.Domain.Models.Users;

public sealed record Nickname
{
    private static readonly Regex NicknameRegex = new(
        @"^[\p{L}\p{N}_-]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public const int MinLength = 3;
    public const int MaxLength = 30;

    public string Value { get; }
    public string NormalizedValue { get; }

    public Nickname(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        value = value.Trim();

        if (value.Length < MinLength || value.Length > MaxLength)
            throw new ArgumentException($"Nickname must contain between {MinLength} and {MaxLength} characters.", nameof(value));

        if (!NicknameRegex.IsMatch(value))
            throw new ArgumentException("Nickname contains invalid characters.", nameof(value));

        Value = value;
        NormalizedValue = value.ToUpperInvariant();
    }

    public static implicit operator string(Nickname nickname) => nickname.Value;

    public override string ToString() => Value;
}