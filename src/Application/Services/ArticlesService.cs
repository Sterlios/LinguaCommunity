using LinguaCommunity.Application.Dtos.Mapping;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace LinguaCommunity.Application.Services;

public class ArticlesService(
    ILogger<ArticlesService> logger, 
    IUserRepository userRepository,
    IArticlesRepository articlesRepository,
    IUnitOfWork unitOfWork)
{
    public async Task CreateArticle(CreateArticleRequest article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteArticle(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ArticleDetailResponse?> GetArticleById(Guid id, CancellationToken cancellationToken)
    { 
        var article = await articlesRepository.GetArticleById(id, cancellationToken);
        var author = await userRepository.GetUserById(article.AuthorId, cancellationToken);

        return article?.ToDetailResponse(author);
    }

    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default) => 
        (await articlesRepository.GetArticles()).Select(a => a.ToItemResponse()).ToList();

    public async Task UpdateArticle(Guid id, UpdateArticleRequest article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}