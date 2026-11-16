namespace LinguaCommunity.Domain.Models.Support;

public record LanguageId(Guid Id) { }
public class Language
{
    public LanguageId Id { get; } = new LanguageId(Guid.CreateVersion7());
    public string Code { get; }
    public string Name { get; }
    public string NativeName { get; }
    public bool IsEnabled { get; private set; } = true;

    public Language(string code, string name, string nativeName)
    {
        Code = code;
        Name = name;
        NativeName = nativeName;
    }

    private Language() { }

    public void Activate() =>
        IsEnabled = true;

    public void Deactivate() =>
        IsEnabled = false;
}
