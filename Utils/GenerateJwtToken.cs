using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Album_Web.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Album_Web.Utils
{
    public static class GenerateJwtToken
    {
        public static string GetJwtToken(UserEntity userEntity)
        {
            var claim = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,userEntity.Email)
            };
            var token = new JwtSecurityToken(JwtTokenConstants.Issuer, JwtTokenConstants.Audience, claim, DateTime.Now, DateTime.Now.AddMinutes(1), JwtTokenConstants.signingCreds);
            var tokenJson = JwtTokenConstants.jwtSecurityTokenHandler.WriteToken(token);
            return tokenJson;
        }
    }
}