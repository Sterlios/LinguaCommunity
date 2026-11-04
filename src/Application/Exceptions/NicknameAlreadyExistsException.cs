namespace LinguaCommunity.Application.Exceptions;

public class NicknameAlreadyExistsException(string nickname)
    : Exception($"Nickname '{nickname}' already exists.")
{
    public string Nickname { get; } = nickname;
}