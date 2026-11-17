using LinguaCommunity.Domain.Models.Articles;

namespace LinguaCommunity.Application.Interfaces;

public interface ITranslationRepository
{
    void AddTranslation(Translation translation);
}