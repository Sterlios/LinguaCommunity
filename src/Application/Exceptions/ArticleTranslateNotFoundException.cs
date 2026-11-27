using LinguaCommunity.Application.Dtos.ReadModels;

namespace LinguaCommunity.Application.Exceptions;

[Serializable]
public class ArticleTranslateNotFoundException(ArticleReadModel article): 
    Exception($"Translate is not found for articleId = {article.Id} and Language = {article.Language.Code}.")
{
    public ArticleReadModel Article => article;
}