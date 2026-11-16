using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Exceptions;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Application.Services;

public class LanguagesService(
    ILanguageRepository languageRepository,
    IUnitOfWork unitOfWork)
{
    public async Task CreateLanguage(LanguageCreateRequest request, CancellationToken cancellationToken)
    {
        var language = new Language(request.Code, request.Name, request.NativeName);
        languageRepository.AddLanguage(language, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<LanguageResponse>> GetEnabledLanguages(CancellationToken cancellationToken)
    {
        var languages = await languageRepository.GetLanguages(cancellationToken);
        return languages
            .Where(l => l.IsEnabled)
            .Select(l => new LanguageResponse(l.Code, l.Name, l.NativeName))
            .ToList();
    }

    public async Task<List<LanguageResponse>> GetLanguages(CancellationToken cancellationToken)
    {
        var languages = await languageRepository.GetLanguages(cancellationToken);
        return languages.Select(l => new LanguageResponse(l.Code, l.Name, l.NativeName)).ToList();
    }

    public async Task UpdateLanguages(LanguagesUpdateRequest request, CancellationToken cancellationToken)
    {
        var languages = await languageRepository.GetLanguagesByCodes(request.Languages.Select(l => l.Code), cancellationToken);

        foreach (var languageRequest in request.Languages)
        {
            var language = languages.FirstOrDefault(l => l.Code == languageRequest.Code)
                ?? throw new LanguageNotFoundException(languageRequest.Code);

            if (languageRequest.IsEnabled)
                language.Activate();
            else
                language.Deactivate();
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}