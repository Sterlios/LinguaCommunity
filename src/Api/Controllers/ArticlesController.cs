using LinguaCommunity.Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Responses;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<ArticlesItemResponse>> GetArticles()
    {
        // Placeholder for getting articles logic
        return Ok(new { Message = "GetArticles endpoint hit" });
    }

    [HttpGet("{id}")]]
    public ActionResult<ArticleDetailResponse> GetArticleById(int id)
    {
        // Placeholder for getting a specific article by ID logic
        return Ok(new { Message = $"GetArticleById endpoint hit with ID: {id}" });
    }

    [HttpPost]
    public IActionResult CreateArticle(CreateArticleRequest article)
    {
        // Placeholder for creating an article logic
        return Ok(new { Message = "CreateArticle endpoint hit" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateArticle(int id, UpdateArticleRequest article)
    {
        // Placeholder for updating an article logic
        return Ok(new { Message = $"UpdateArticle endpoint hit with ID: {id}" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteArticle(int id)
    {
        // Placeholder for deleting an article logic
        return Ok(new { Message = $"DeleteArticle endpoint hit with ID: {id}" });
    }
}
