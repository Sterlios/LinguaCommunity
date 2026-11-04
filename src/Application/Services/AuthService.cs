using LinguaCommunity.Application.Dtos.Requests;

namespace LinguaCommunity.Application.Services;

public class AuthService
{
    public async Task LoginUser(LoginRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterUser(RegisterRequest request, CancellationToken cancellationToken)
    {//Реализовать регистрацию пользователя с проверкой данных и сохранением в базу данных
        // Здесь должна быть логика регистрации пользователя
        
    }
}