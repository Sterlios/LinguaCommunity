namespace LinguaCommunity.Domain.Models.Support;

public record LanguageId(Guid Guid){}
public class Language(string name)
{
    public LanguageId Id { get; } = new LanguageId(Guid.CreateVersion7());
    public string Name { get; } = name;
    public bool IsEnabled { get; private set; } = true;
}
