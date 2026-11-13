using LinguaCommunity.Domain.Models.Translations;

namespace LinguaCommunity.Application.Interfaces;

public interface ITranslationRepository
{
    void AddTranslation(Translation translation);
}