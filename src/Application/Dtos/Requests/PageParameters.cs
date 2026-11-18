namespace LinguaCommunity.Application.Dtos.Requests;

public record PageParameters(
    int Page = 1, 
    int PageSize = 10
    );