using LinguaCommunity.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LinguaCommunity.Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    private static readonly object User = new();

    public string HashPassword(string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        return _passwordHasher.HashPassword(User, password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(hashedPassword);

        var result = _passwordHasher.VerifyHashedPassword(
            User,
            hashedPassword,
            password);

        return result != PasswordVerificationResult.Failed;
    }
}
