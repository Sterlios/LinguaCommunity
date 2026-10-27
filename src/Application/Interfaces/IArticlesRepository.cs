using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface IArticlesRepository
{
    Task<Article> GetArticleById(Guid id, CancellationToken cancellationToken);
    Task<List<Article>> GetArticles();
}