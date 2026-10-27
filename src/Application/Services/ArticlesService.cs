using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;

namespace LinguaCommunity.Application.Services;

public class ArticlesService
{
    public async Task CreateArticle(CreateArticleRequest article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteArticle(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ArticleDetailResponse> GetArticleById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateArticle(Guid id, UpdateArticleRequest article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}