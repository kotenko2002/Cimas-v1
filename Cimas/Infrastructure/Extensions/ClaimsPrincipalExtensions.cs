using System;
using System.Security.Claims;

namespace Cimas.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(principal.FindFirstValue("userId"));
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Role);
        }

        public static int GetCompanyId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(principal.FindFirstValue("companyId"));
        }
    }
}
