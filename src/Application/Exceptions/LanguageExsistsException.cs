namespace LinguaCommunity.Application.Exceptions;

[Serializable]
public class LanguageExsistsException(string code)
    : Exception($"Language already exsists: {code}")
{
    public string Code { get; } = code;
}