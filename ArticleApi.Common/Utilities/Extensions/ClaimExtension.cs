using Microsoft.IdentityModel.JsonWebTokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace ArticleApi.Common.Utilities.Extensions
{
    public static class ClaimExtension
    {
        public static void AddUserIdentifier(this ICollection<Claim> claims,string usrid)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, usrid));
        }
    }
}
