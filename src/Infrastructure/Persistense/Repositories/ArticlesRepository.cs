using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense.Repositories;

public class ArticlesRepository(ArticlesContext context) : IArticlesRepository
{
    public void AddArticle(Article article) =>
        context.Articles.Add(article);

    public void DeleteArticle(Article article) =>
        context.Articles.Remove(article);

    public async Task<Article?> GetArticleById(Guid id, CancellationToken cancellationToken) =>
        await context.Articles
            .FirstOrDefaultAsync(a => a.Id.Id == id, cancellationToken);

    public async Task<Article?> ReadArticleById(Guid id, CancellationToken cancellationToken) =>
        await context.Articles
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id.Id == id, cancellationToken);

    public async Task<List<Article>> ReadArticles(CancellationToken cancellationToken) =>
        await context.Articles
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}