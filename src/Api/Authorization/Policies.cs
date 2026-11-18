using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Api.Authorization;

public static class Policies
{
    public const string AdminOnly = "AdminOnly";
    public static string[] AllowedAdmin = [Role.Admin.ToString()]; //TODO выглядит как костыль, но пока что так (нормально ли, что Api залезает в Domain?)
}
