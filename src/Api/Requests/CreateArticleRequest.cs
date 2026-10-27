namespace LinguaCommunity.Api.Requests;

public record CreateArticleRequest
(
    string Title,
    string Content,
    string Language
);