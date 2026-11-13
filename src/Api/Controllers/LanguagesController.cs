using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(LanguagesService languagesService): ControllerBase
{
    [HttpGet]
    public async Task<List<LanguageResponse>> GetLanguages(CancellationToken cancellationToken)
    {
        var languages = await languagesService.GetAllLanguages(cancellationToken);
        return Ok(languages);
    }
}
