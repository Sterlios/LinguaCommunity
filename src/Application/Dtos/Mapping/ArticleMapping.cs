using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Application.Dtos.Mapping;

public static class ArticleMapping
{
    public static ArticleDetailResponse ToDetailResponse(this Article article, User author) =>
        new ArticleDetailResponse(
            Title: article.Title,
            Content: article.Content,
            Author: new AuthorResponse(
                Id: author.Id.Id,
                Name: author.Name
            ),
            CreatedAt: article.CreatedAt,
            UpdatedAt: article.UpdatedAt
        );

    public static ArticlesItemResponse ToItemResponse(this Article article, User author) =>
        new ArticlesItemResponse(
            Title: article.Title,
            Author: new AuthorResponse(
                Id: author.Id.Id,
                Name: author.Name
            ),
            CreatedAt: article.CreatedAt,
            UpdatedAt: article.UpdatedAt
            );
}
