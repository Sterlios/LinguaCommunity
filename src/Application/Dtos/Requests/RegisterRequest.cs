namespace LinguaCommunity.Application.Dtos.Requests;

public record RegisterRequest(
    string Email, 
    string Password, 
    string PasswordConfirmation, 
    string Nickname
);
