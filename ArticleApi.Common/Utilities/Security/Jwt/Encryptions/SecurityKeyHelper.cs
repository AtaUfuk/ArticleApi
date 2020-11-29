using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ArticleApi.Common.Utilities.Encryptions
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
        }
    }
}
