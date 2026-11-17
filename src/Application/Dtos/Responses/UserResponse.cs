namespace LinguaCommunity.Application.Dtos.Responses;

public record UserResponse(
    Guid Id,
    string Email,
    string Nickname,
    string Role
);