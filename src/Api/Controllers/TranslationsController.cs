using LinguaCommunity.Api.Authorization;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = Policies.AdminOnly)]
public class TranslationsController(TranslationsService translationsService): ControllerBase
{
    [HttpGet]
    public async Task<List<TranslationResponse>> GetTranslations(PageParameters pageParameters, CancellationToken cancellationToken) =>
        await translationsService.GetTranslations(pageParameters, cancellationToken);

    [HttpPost]
    public async Task StartTranslation(TranslateArticleRequest translateArticleRequest, CancellationToken cancellationToken) =>
        translationsService.StartTranslate(translateArticleRequest, cancellationToken);
}
