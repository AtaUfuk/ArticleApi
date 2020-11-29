using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Encryptions;
using ArticleApi.Common.Utilities.Extensions;
using ArticleApi.Common.Utilities.Security.Jwt.Encryptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ArticleApi.Common.Utilities.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions { get; set; }
        private DateTime _accessTokenExpireDate { get; set; }
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpireDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(AutUserInfo userInfo)
        {
            var securitykey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var singingCredentials = Encryption.CreateSigningCredentials(securitykey);
            var jwt= CreateJwtSecurityToken(_tokenOptions, userInfo, singingCredentials);
            var _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpireDate
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AutUserInfo userInfo, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: _accessTokenExpireDate,
                signingCredentials: signingCredentials,
                claims: SetClaims(userInfo)
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AutUserInfo info)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddUserIdentifier(info.UsrId.ToString());
            return claims;
        }
    }
}
