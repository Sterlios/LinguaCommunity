using LinguaCommunity.Application.Dtos;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Exceptions;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Services;

public class AuthService(
    IUsersRepository usersRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    IUnitOfWork unitOfWork)
{
    public async Task<AuthResponse> LoginUser(LoginRequest request, CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);
        var user = await usersRepository.ReadUserByEmail(email, cancellationToken);

        if (user == null || !passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new InvalidLoginException();

        var tokenPayload = new TokenPayload(user.Id);

        return new AuthResponse(Token: tokenService.GenerateToken(tokenPayload));
    }

    public async Task RegisterUser(RegisterRequest request, CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);

        if (await usersRepository.ExistsEmail(email, cancellationToken))
            throw new EmailAlreadyExistsException(email);

        var nickname = new Nickname(request.Nickname);

        if (await usersRepository.ExistsNickname(nickname, cancellationToken))
            throw new NicknameAlreadyExistsException(nickname);

        var hashedPassword = passwordHasher.HashPassword(request.Password);

        var user = new User(
            email: email,
            passwordHash: hashedPassword,
            nickname: nickname
        );

        usersRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken); // TODO: предусмотреть race condition, когда два запроса на регистрацию с одинаковым email приходят одновременно
    }
}