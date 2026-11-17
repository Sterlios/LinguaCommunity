using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class ArticlesRepository(ArticlesContext context): IArticlesRepository
{
    public void AddArticle(Article article) =>
        context.Articles.Add(article);

    public void DeleteArticle(Article article) =>
        context.Articles.Remove(article);

    public async Task<Article?> GetArticleById(ArticleId id, CancellationToken cancellationToken) =>
        await context.Articles
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

    public async Task<Article?> ReadArticle(ArticleId id, CancellationToken cancellationToken) =>
        await context.Articles
            .AsNoTracking()
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

    public async Task<List<Article>> ReadArticles(PageParameters pageParameters, CancellationToken cancellationToken) =>
        await context.Articles
            .AsNoTracking()
            .Skip((pageParameters.Page - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize)
            .ToListAsync(cancellationToken);
}