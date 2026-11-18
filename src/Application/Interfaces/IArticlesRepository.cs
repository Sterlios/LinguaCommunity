using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface IArticlesRepository
{
    void AddArticle(Article article);
    Task<Article?> GetArticleById(ArticleId id, CancellationToken cancellationToken);
    Task<List<Article>> ReadArticles(PageParameters pageParameters, CancellationToken cancellationToken);
    Task<Article?> ReadArticle(ArticleId id, CancellationToken cancellationToken);
    void DeleteArticle(Article article);
}