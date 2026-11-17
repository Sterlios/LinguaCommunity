using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Dtos.Mapping;

public static class UserMapping
{
    public static UserResponse ToResponse(this User user) =>
        new(
            Id: user.Id.Id,
            Email: user.Email.Value,
            Nickname: user.Nickname.Value,
            Role: user.Role.ToString()
        );
}
