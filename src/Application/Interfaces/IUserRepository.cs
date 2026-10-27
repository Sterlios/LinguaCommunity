using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Interfaces
{
    internal interface IUserRepository
    {
        Task<User> GetUserById(UserId authorId, CancellationToken cancellationToken);
    }
}