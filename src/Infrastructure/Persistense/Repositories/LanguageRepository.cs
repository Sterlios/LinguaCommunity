using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Support;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class LanguageRepository(ArticlesContext context): ILanguageRepository
{
    public async Task<IEnumerable<Language>> GetAllLanguages(CancellationToken cancellationToken) => 
        await context.Languages
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}
