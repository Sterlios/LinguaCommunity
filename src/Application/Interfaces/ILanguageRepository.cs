using LinguaCommunity.Application.Services;
using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Application.Interfaces;

public interface ILanguageRepository
{
    void AddLanguage(Language language, CancellationToken cancellationToken);
    Task<IEnumerable<Language>> GetLanguages(CancellationToken cancellationToken);
    Task<List<Language>> GetLanguagesByCodes(IEnumerable<string> codes, CancellationToken cancellationToken);
}