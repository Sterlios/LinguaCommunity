using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Api.Authorization;

public class Policies
{
    public const string AdminOnly = "AdminOnly";
    public static string[] AllowedAdmin = [ Role.Admin.ToString() ];
}
