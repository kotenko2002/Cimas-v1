using System.Security.Claims;

namespace Cimas.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Role);
        }
    }
}
