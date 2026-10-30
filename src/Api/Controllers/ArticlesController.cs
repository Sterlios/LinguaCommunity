using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Requests;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController(ArticlesService service) : ControllerBase
{
    [HttpGet]
    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default) => 
        await service.GetArticles(cancellationToken);

    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDetailResponse>> GetArticleById(Guid id, CancellationToken cancellationToken = default)
    {
        var article = await service.GetArticleById(id, cancellationToken);

        if (article == null)
            return NotFound();

        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(CreateArticleRequest article, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Empty; // TODO: Replace with actual user ID retrieval logic (e.g., from authentication context)

        await service.CreateArticle(
            authorId: userId, 
            articleData: article, 
            cancellationToken);

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(Guid id, UpdateArticleRequest article, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Empty; // TODO: Replace with actual user ID retrieval logic (e.g., from authentication context)

        await service.UpdateArticle(
            articleId: id, 
            authorId: id, 
            articleData: article, 
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(Guid id, CancellationToken cancellationToken = default)
    {
        var userId = Guid.Empty; // TODO: Replace with actual user ID retrieval logic (e.g., from authentication context)

        await service.DeleteArticle(
            authorId: userId, 
            articleId: id, 
            cancellationToken: cancellationToken);

        return NoContent();
    }
}
