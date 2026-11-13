using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Interfaces;

namespace LinguaCommunity.Application.Services;

public class LanguagesService(ILanguageRepository languageRepository)
{
    public async Task<List<LanguageResponse>> GetAllLanguages(CancellationToken cancellationToken) => 
        throw new NotImplementedException();
}