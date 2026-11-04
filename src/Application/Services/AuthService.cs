using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Exceptions;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace LinguaCommunity.Application.Services;

public class AuthService(
    IUsersRepository usersRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    IUnitOfWork unitOfWork )
{
    public async Task LoginUser(LoginRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterUser(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (request.Password != request.PasswordConfirmation)
            throw new ValidationException("Passwords do not match.");

        var email = new Email(request.Email);

        if (await usersRepository.ExistsEmail(email, cancellationToken))
            throw new EmailAlreadyExistsException(email);

        var nickname = new Nickname(request.Nickname);

        if (await usersRepository.ExistsNickname(nickname, cancellationToken))
            throw new NicknameAlreadyExistsException(nickname);

        var name = new Name(request.FirstName, request.LastName);
        var hashedPassword = passwordHasher.HashPassword(request.Password);

        var user = new User(
            email: email,
            passwordHash: hashedPassword,
            nickname: nickname,
            name: name
        );

        usersRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}