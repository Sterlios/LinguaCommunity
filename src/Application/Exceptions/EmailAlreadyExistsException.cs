using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Exceptions;

[Serializable]
public class EmailAlreadyExistsException(string email)
    : Exception($"Email '{email}' already exists.")
{
    public string Email { get; } = email;
}