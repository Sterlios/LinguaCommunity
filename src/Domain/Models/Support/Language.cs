namespace LinguaCommunity.Domain.Models.Support;

public record LanguageId(Guid Id) { }
public class Language
{
    public LanguageId Id { get; } = new LanguageId(Guid.CreateVersion7());
    public string Code { get; } = null!;
    public string Name { get; } = null!;
    public string NativeName { get; } = null!;
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
