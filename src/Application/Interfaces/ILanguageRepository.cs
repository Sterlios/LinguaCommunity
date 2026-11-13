using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Application.Interfaces;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> GetAllLanguages(CancellationToken cancellationToken);
}