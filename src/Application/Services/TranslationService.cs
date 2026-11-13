using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Translations;

namespace LinguaCommunity.Application.Services;

public class TranslationService(
    ILanguageRepository languageRepository,
    ITranslationRepository translationRepository)
{
    public async Task CreateTasks(Article article, CancellationToken cancellationToken)
    {
        var targetLanguages = await languageRepository.GetAllLanguages(cancellationToken);
        
        foreach (var targetLanguage in targetLanguages)
        {
            if (targetLanguage != article.Language)
            {
                var translation = new Translation(article, targetLanguage);
                translationRepository.AddTranslation(translation);
            }
        }
    }
}
