using LinguaCommunity.Application.Dtos.ReadModels;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface IArticlesRepository
{
    void AddArticle(Article article);
    Task<Article?> GetArticleById(ArticleId id, CancellationToken cancellationToken);
    Task<List<Article>> ReadArticles(PageParameters pageParameters, CancellationToken cancellationToken);
    Task<ArticleReadModel?> ReadArticle(ArticleId id, string langCode, CancellationToken cancellationToken);
    void DeleteArticle(Article article);
    Task<Article?> GetArticle(ArticleId articleVoId, CancellationToken cancellationToken);
}