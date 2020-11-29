namespace ArticleApi.Common.Utilities.Jwt
{
    public class TokenOptions
    {
        /// <summary>
        /// Kullanıcı kitlesi
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// imzalayan
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Dakika cinsinden
        /// </summary>
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
