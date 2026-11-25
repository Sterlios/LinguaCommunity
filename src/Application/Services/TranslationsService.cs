using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Services;

public class TranslationsService(
    ILanguageRepository languageRepository,
    ITranslationRepository translationRepository)
{
    public async Task<List<TranslationResponse>> GetTranslations(PageParameters pageParameters, CancellationToken cancellationToken) => throw new NotImplementedException();
    public void StartTranslate(TranslateArticleRequest translateArticleRequest, CancellationToken cancellationToken) => throw new NotImplementedException();

    internal async Task CreateTasks(Article article, CancellationToken cancellationToken)
    {
        var targetLanguages = await languageRepository.GetLanguages(cancellationToken);
        
        foreach (var targetLanguage in targetLanguages)
        {
            if (targetLanguage.Id != article.LanguageId && targetLanguage.IsEnabled)
            {
                var translation = new Translation(article, targetLanguage.Id);
                translationRepository.AddTranslation(translation);
            }
        }
    }
}
