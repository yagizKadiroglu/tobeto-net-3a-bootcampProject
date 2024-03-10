using Amazon.Auth.AccessControlPolicy;
using System.Security.Claims;

namespace Core.Extensions;

public static class ClaimPrincipalExtensions
{
    public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(x=>x.Value).ToList();
        return result;
    }

    public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }

    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return int.Parse(claimsPrincipal.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }
}
