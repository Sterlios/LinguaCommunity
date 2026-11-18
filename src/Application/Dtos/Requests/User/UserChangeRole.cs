using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Dtos.Requests.User;

public record UserChangeRole(Guid UserId, Role NewRole);
