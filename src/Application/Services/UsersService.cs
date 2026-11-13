using LinguaCommunity.Application.Dtos.Requests;
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
            ?? throw new Exception("User not found");

        user.ChangeRole(request.NewRole);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
