using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Support;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class LanguageRepository(ArticlesContext context): ILanguageRepository
{
    public void AddLanguage(Language language, CancellationToken cancellationToken) =>
        context.Languages.Add(language);

    public async Task<Language?> GetLanguageByCode(string languageCode, CancellationToken cancellationToken) =>
        await context.Languages.SingleOrDefaultAsync(l => l.Code == languageCode, cancellationToken: cancellationToken);
    
    public async Task<IEnumerable<Language>> GetLanguages(CancellationToken cancellationToken) =>
        await context.Languages
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public Task<List<Language>> GetLanguagesByCodes(IEnumerable<string> codes, CancellationToken cancellationToken) =>
        context.Languages
            .Where(l => codes.Contains(l.Code))
            .ToListAsync(cancellationToken);
}
