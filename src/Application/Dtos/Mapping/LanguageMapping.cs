using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Application.Dtos.Mapping;

public static class LanguageMapping
{
    public static LanguageResponse ToResponse(this Language language) =>
        new(
            Code: language.Code,
            Name: language.Name,
            NativeName: language.NativeName
        );
}
