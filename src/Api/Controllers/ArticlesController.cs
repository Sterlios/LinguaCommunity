using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController(ArticlesService service): ControllerBase
{
    [HttpGet]
    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default) =>
        await service.GetArticles(cancellationToken);

    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDetailResponse>> GetArticleById(Guid id, CancellationToken cancellationToken = default)
    {
        var article = await service.GetArticleById(id, cancellationToken);

        return article switch
        {
            null => (ActionResult<ArticleDetailResponse>)NotFound(),
            _ => (ActionResult<ArticleDetailResponse>)Ok(article),
        };
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateArticle(CreateArticleRequest article, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

        await service.CreateArticle(
            authorId: userId,
            articleData: article,
            cancellationToken);

        return Created();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateArticle(Guid id, UpdateArticleRequest article, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

        await service.UpdateArticle(
            articleId: id,
            authorId: userId,
            articleData: article,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteArticle(Guid id, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

        await service.DeleteArticle(
            authorId: userId,
            articleId: id,
            cancellationToken: cancellationToken);

        return NoContent();
    }
}
