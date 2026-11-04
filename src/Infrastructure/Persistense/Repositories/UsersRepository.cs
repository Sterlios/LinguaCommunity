using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class UsersRepository(ArticlesContext context) : IUsersRepository
{
    public async Task<User?> ReadUserById(UserId authorId, CancellationToken cancellationToken) =>
        await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == authorId, cancellationToken);

    public async Task<List<User>> ReadUsersByIds(List<UserId> userIds, CancellationToken cancellationToken) =>
        await context.Users
            .AsNoTracking()
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync(cancellationToken);
}
