using System;
using System.Security.Claims;

namespace Cimas.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(GetInfoByDataName(principal, "userId"));
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            return GetInfoByDataName(principal, ClaimTypes.Role);
        }

        public static int GetCompanyId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(GetInfoByDataName(principal, "companyId"));
        }

        private static string GetInfoByDataName(ClaimsPrincipal principal, string name)
        {
            var data = principal.FindFirstValue(name);

            if(data == null)
            {
                throw new Exception($"No such data as {name} in Token");
            }

            return data;
        }
    }
}
