namespace LinguaCommunity.Application.Dtos.Requests.Article;

public record CreateArticleRequest
(
    string Title,
    string Content,
    Guid LanguageId
);