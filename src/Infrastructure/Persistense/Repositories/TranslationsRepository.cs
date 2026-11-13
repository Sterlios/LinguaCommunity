using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Translations;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class TranslationsRepository(ArticlesContext context): ITranslationRepository
{
    public void AddTranslation(Translation translation) => 
        context.Translations.Add(translation);
}
