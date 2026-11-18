using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class UsersRepository(ArticlesContext context): IUsersRepository
{
    public void Add(User user) =>
        context.Users.Add(user);

    public Task<bool> ExistsEmail(Email email, CancellationToken cancellationToken) =>
        context.Users
            .AnyAsync(u => u.Email == email, cancellationToken);

    public Task<bool> ExistsNickname(Nickname nickname, CancellationToken cancellationToken) =>
        context.Users
            .AnyAsync(u => u.Nickname == nickname, cancellationToken);

    public Task<User?> GetUserById(UserId userId, CancellationToken cancellationToken) =>
        context.Users
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

    public async Task<List<User>> ReadUsers(PageParameters pageParameters, CancellationToken cancellationToken) =>
        await context.Users
            .AsNoTracking()
            .Skip((pageParameters.Page - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize)
            .ToListAsync(cancellationToken);

    public async Task<bool> HasAnyUsers(CancellationToken cancellationToken) => 
        await context.Users
            .AnyAsync(cancellationToken);

    public Task<User?> ReadUserByEmail(Email email, CancellationToken cancellationToken) =>
        context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

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
