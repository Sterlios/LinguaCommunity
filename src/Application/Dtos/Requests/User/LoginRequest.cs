namespace LinguaCommunity.Application.Dtos.Requests.User;

public record LoginRequest(
    string Email, 
    string Password
);