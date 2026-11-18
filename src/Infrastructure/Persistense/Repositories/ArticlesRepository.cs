using LinguaCommunity.Application.Dtos.ReadModels;
using LinguaCommunity.Application.Dtos.Requests;
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

    public async Task<Article?> GetArticle(ArticleId articleVoId, CancellationToken cancellationToken) =>
        await context.Articles
            .FirstOrDefaultAsync(a => a.Id == articleVoId, cancellationToken);

    public async Task<Article?> GetArticleById(ArticleId id, CancellationToken cancellationToken) =>
        await context.Articles
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

    public async Task<ArticleReadModel?> ReadArticle(ArticleId id, string langCode, CancellationToken cancellationToken) =>
        await context.Database.SqlQueryRaw<ArticleReadModel>(
            @"SELECT 
                a.Id, 
                ISNULL(t.Title, a.Title) AS Title,  
                ISNULL(t.Content, a.Content) AS Content,  
                a.CreatedAt,  
                a.UpdatedAt, 
                u.Id AS AuthorId,  
                u.Nickname AS AuthorNickname, 
                l.Code AS LanguageCode,  
                l.Name AS LanguageName,  
                l.NativeName AS LanguageNativeName
            FROM Articles a
            JOIN Users u 
                ON a.AuthorId = u.Id
            LEFT JOIN Translations t 
                ON a.Id = t.ArticleId
            JOIN Languages l 
                ON (a.LanguageId = l.Id
                OR t.TargetLanguageId = l.Id) 
                AND l.Code = {1}    
            WHERE a.Id = {0}", id.Id, langCode)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<Article>> ReadArticles(PageParameters pageParameters, CancellationToken cancellationToken) =>
        await context.Articles
            .AsNoTracking()
            .Skip((pageParameters.Page - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize)
            .ToListAsync(cancellationToken);
}