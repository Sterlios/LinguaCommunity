using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Exceptions;

public class NicknameAlreadyExistsException(Nickname nickname)
    : Exception($"Nickname '{nickname.NormalizedValue}' already exists.")
{
    public Nickname Nickname { get; } = nickname;
}