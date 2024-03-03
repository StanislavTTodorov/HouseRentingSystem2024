using System.Security.Claims;

namespace HouseRentingSystem.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalEtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
