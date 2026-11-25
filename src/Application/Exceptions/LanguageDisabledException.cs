using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Application.Exceptions;

[Serializable]
public class LanguageDisabledException(Language language): Exception($"Language is disabled: {language.Code}")
{
}