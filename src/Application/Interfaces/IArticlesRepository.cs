using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface IArticlesRepository
{
    void AddArticle(Article article);
    Task<Article?> GetArticleById(ArticleId id, CancellationToken cancellationToken);
    Task<List<Article>> ReadArticles(CancellationToken cancellationToken);
    Task<Article?> ReadArticleById(ArticleId id, CancellationToken cancellationToken);
    void DeleteArticle(Article article);
}