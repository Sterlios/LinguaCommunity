namespace LinguaCommunity.Application.Dtos.Requests.User;

public record RegisterRequest(
    string Email, 
    string Password, 
    string PasswordConfirmation, 
    string Nickname
);
