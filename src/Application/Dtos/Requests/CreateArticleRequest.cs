namespace LinguaCommunity.Application.Dtos.Requests;

public record CreateArticleRequest
(
    string Title,
    string Content,
    string Language
);