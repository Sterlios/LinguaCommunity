namespace LinguaCommunity.Application.Exceptions;

[Serializable]
public class LanguageNotFoundException(string code)
    : Exception($"Language with code '{code}' not found.")
{
    public string Code { get; } = code;
}