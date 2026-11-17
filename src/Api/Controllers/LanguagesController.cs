using LinguaCommunity.Api.Authorization;
using LinguaCommunity.Application.Dtos.Requests.Language;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(LanguagesService languagesService): ControllerBase
{
    [HttpGet]
    public async Task<List<LanguageResponse>> GetEnabledLanguages(CancellationToken cancellationToken)
    {
        var languages = await languagesService.GetEnabledLanguages(cancellationToken);
        return languages;
    }

    [HttpGet("admin")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<List<LanguageResponse>> GetLanguages(CancellationToken cancellationToken)
    {
        var languages = await languagesService.GetLanguages(cancellationToken);
        return languages;
    }

    [HttpPost("admin")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> CreateLanguage([FromBody] LanguageCreateRequest request, CancellationToken cancellationToken)
    {
        await languagesService.CreateLanguage(request, cancellationToken);
        return CreatedAtAction(nameof(GetLanguages), new { }, null);
    }

    [HttpPut("admin")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> UpdateLanguages([FromBody] LanguagesUpdateRequest request, CancellationToken cancellationToken)
    {
        await languagesService.UpdateLanguages(request, cancellationToken);
        return NoContent();
    }
}
