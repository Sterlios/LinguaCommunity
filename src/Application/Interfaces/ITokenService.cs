using LinguaCommunity.Application.Dtos;

namespace LinguaCommunity.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(TokenPayload payload);
}