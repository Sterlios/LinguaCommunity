using LinguaCommunity.Application.Dtos.Mapping;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.Extensions.Logging;

namespace LinguaCommunity.Application.Services;

public class ArticlesService(
    ILogger<ArticlesService> logger, 
    IUserRepository userRepository,
    IArticlesRepository articlesRepository,
    IUnitOfWork unitOfWork)
{
    public async Task CreateArticle(Guid authorId, CreateArticleRequest articleData, CancellationToken cancellationToken)
    {
        var article = new Article(
            authorId: new UserId(authorId),
            title: articleData.Title,
            content: articleData.Content,
            language: Enum.Parse<Language>(articleData.Language)
            );

        articlesRepository.AddArticle(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Article created with ID: {ArticleId} by Author ID: {AuthorId}", article.Id, authorId);
    }

    public async Task DeleteArticle(Guid authorId, Guid id, CancellationToken cancellationToken)
    {
        var article = await articlesRepository.ReadArticleById(id, cancellationToken) ?? 
            throw new InvalidOperationException($"Article with ID {id} not found."); // TODO: Consider creating a custom exception for this scenario.

        if (article.AuthorId.Id != authorId)
            throw new InvalidOperationException($"User with ID {authorId} is not the author of the article with ID {id}.");// TODO: Consider creating a custom exception for this scenario.

        articlesRepository.DeleteArticle(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ArticleDetailResponse?> GetArticleById(Guid id, CancellationToken cancellationToken)
    { 
        var article = await articlesRepository.ReadArticleById(id, cancellationToken) ?? 
            throw new InvalidOperationException($"Article with ID {id} not found."); // TODO: Consider creating a custom exception for this scenario.
        var author = await userRepository.ReadUserById(article.AuthorId, cancellationToken);

        return article?.ToDetailResponse(author);
    }

    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default)
    {
        var articles = await articlesRepository.ReadArticles(cancellationToken);
        var authors = await userRepository.ReadUsersByIds(articles.Select(a => a.AuthorId).ToList(), cancellationToken);

        return articles.Select(a => a.ToItemResponse(authors.First(u => u.Id == a.AuthorId))).ToList();
    } 

    public async Task UpdateArticle(Guid id, Guid authorId, UpdateArticleRequest articleData, CancellationToken cancellationToken)
    {
        var article = await articlesRepository.GetArticleById(id, cancellationToken) ?? 
            throw new InvalidOperationException($"Article with ID {id} not found."); // TODO: Consider creating a custom exception for this scenario.

        if (article.AuthorId.Id != authorId)
            throw new InvalidOperationException($"User with ID {authorId} is not the author of the article with ID {id}.");// TODO: Consider creating a custom exception for this scenario.

        article.Update(articleData.Title, articleData.Content);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}