using LinguaCommunity.Application.Dtos.Mapping;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Exceptions;
using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.Extensions.Logging;

namespace LinguaCommunity.Application.Services;

public class ArticlesService(
    ILogger<ArticlesService> logger,
    IUsersRepository userRepository,
    IArticlesRepository articlesRepository,
    TranslationService translationService,
    IUnitOfWork unitOfWork)
{
    public async Task CreateArticle(Guid authorId, CreateArticleRequest articleData, CancellationToken cancellationToken)
    {
        var article = new Article(
            authorId: new UserId(authorId),
            title: articleData.Title,
            content: articleData.Content,
            languageId: new LanguageId(articleData.LanguageId)
            );

        articlesRepository.AddArticle(article);

        await translationService.CreateTasks(article, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Article created with ID: {ArticleId} by Author ID: {AuthorId}", article.Id, authorId);
    }

    public async Task DeleteArticle(Guid authorId, Guid articleId, CancellationToken cancellationToken)
    {
        var articleVoId = new ArticleId(articleId);

        var article = await articlesRepository.ReadArticleById(articleVoId, cancellationToken) ??
            throw new ArticleNotFoundException(articleId);

        if (article.AuthorId.Id != authorId)
            throw new AccessDeniedException(authorId, articleId, "Only the author of an article can delete it.");

        articlesRepository.DeleteArticle(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ArticleDetailResponse> GetArticleById(Guid articleId, CancellationToken cancellationToken)
    {
        var articleVoId = new ArticleId(articleId);

        var article = await articlesRepository.ReadArticleById(articleVoId, cancellationToken) ??
            throw new ArticleNotFoundException(articleId);

        var author = await userRepository.ReadUserById(article.AuthorId, cancellationToken) ??
            throw new InvalidOperationException($"Author with ID {article.AuthorId} not found.");

        return article.ToDetailResponse(author);
    }

    public async Task<List<ArticlesItemResponse>> GetArticles(CancellationToken cancellationToken = default)
    {
        var articles = await articlesRepository.ReadArticles(cancellationToken);
        var articlesAuthorIds = articles.Select(a => a.AuthorId).Distinct().ToList();

        var authors = await userRepository.ReadUsersByIds(articlesAuthorIds, cancellationToken);

        if (authors.Count != articlesAuthorIds.Count)
        {
            var missingAuthorIds = articlesAuthorIds
                .Where(authorId => !authors.Any(u => u.Id == authorId))
                .Select(authorId => authorId.Id)
                .ToList();

            logger.LogWarning(
                "Some authors were not found for the retrieved articles. Missing Author IDs: {MissingAuthorIds}",
                string.Join(", ", missingAuthorIds));
        }

        return [.. articles
            .Where(a => authors.Any(x => x.Id == a.AuthorId))
            .Select(a => a.ToItemResponse(authors.First(u => u.Id == a.AuthorId)))];
    }

    public async Task UpdateArticle(Guid articleId, Guid authorId, UpdateArticleRequest articleData, CancellationToken cancellationToken)
    {
        var articleVoId = new ArticleId(articleId);

        var article = await articlesRepository.GetArticleById(articleVoId, cancellationToken) ??
            throw new ArticleNotFoundException(articleId);

        if (article.AuthorId.Id != authorId)
            throw new AccessDeniedException(authorId, articleId, "Only the author of an article can update it.");

        article.Update(articleData.Title, articleData.Content);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}