using LinguaCommunity.Application.Dtos.Mapping;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Requests.User;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Services;

public class UsersService(
    IUsersRepository usersRepository,
    IUnitOfWork unitOfWork)
{
    public async Task ChangeRole(UserChangeRole request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetUserById(new UserId(request.UserId), cancellationToken)
            ?? throw new Exception("User not found"); // TODO custom exception

        user.ChangeRole(request.NewRole);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<UserResponse>> GetUsers(PageParameters pageParameters, CancellationToken cancellationToken)
    {
        var users = await usersRepository.ReadUsers(pageParameters, cancellationToken);
        return users.Select(u => u.ToResponse()).ToList();
    }

    internal async Task<List<User>> ReadUsersByIds(List<UserId> articlesAuthorIds, CancellationToken cancellationToken) => 
        await usersRepository.ReadUsersByIds(articlesAuthorIds, cancellationToken);
}
