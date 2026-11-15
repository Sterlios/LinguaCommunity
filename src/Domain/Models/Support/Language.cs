namespace LinguaCommunity.Domain.Models.Support;

public record LanguageId(Guid Id){}
public class Language(string code, string name, string nativeName)
{
    public LanguageId Id { get; } = new LanguageId(Guid.CreateVersion7());
    public string Code { get; } = code;
    public string Name { get; } = name;
    public string NativeName { get; } = nativeName;
    public bool IsEnabled { get; private set; } = true;

    public void Activate() => throw new NotImplementedException();
    public void Deactivate() => throw new NotImplementedException();
}
