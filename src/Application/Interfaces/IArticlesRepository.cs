using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface IArticlesRepository
{
    void AddArticle(Article article);
    Task<Article?> GetArticleById(Guid id, CancellationToken cancellationToken);
    Task<List<Article>> ReadArticles(CancellationToken cancellationToken);
    Task<Article?> ReadArticleById(Guid id, CancellationToken cancellationToken);
    void DeleteArticle(Article article);
}