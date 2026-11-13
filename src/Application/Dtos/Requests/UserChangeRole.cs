using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Dtos.Requests;

public record UserChangeRole(Guid UserId, Role NewRole);
