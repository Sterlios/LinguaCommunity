namespace LinguaCommunity.Domain.Models.Users;

public record struct UserId(Guid Id);
public class User
{
    public UserId Id { get; }
    public string Name { get; } = null!;
}