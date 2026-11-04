using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Interfaces;

public interface IUsersRepository
{
    Task<List<User>> ReadUsersByIds(List<UserId> userIds, CancellationToken cancellationToken);
    Task<User?> ReadUserById(UserId authorId, CancellationToken cancellationToken);
    Task<User?> ReadUserByEmail(Email email, CancellationToken cancellationToken);
    Task<bool> ExistsEmail(Email email, CancellationToken cancellationToken);
    Task<bool> ExistsNickname(Nickname nickname, CancellationToken cancellationToken);
    void Add(User user);
}