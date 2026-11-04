namespace LinguaCommunity.Domain.Models.Users;

public record struct UserId(Guid Id);

public class User
{
    public User(Email email, Nickname nickname, Name name, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrEmpty(passwordHash);

        Id = new UserId(Guid.CreateVersion7());
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PasswordHash = passwordHash;
    }

    public UserId Id { get; }
    public Email Email { get; private set; }
    public Nickname Nickname { get; }
    public Name Name { get; private set; }
    public string PasswordHash { get; private set; }
}