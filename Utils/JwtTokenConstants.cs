using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace Album_Web.Utils
{
    public static class JwtTokenConstants
    {
        public const string Secret = "codinlog@foxmail.com";
        public const string Issuer = "http://localhost:5000";
        public const string Audience = "http://localhost:5000";
        public static JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        public static SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenConstants.Secret));
        public static SigningCredentials signingCreds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    }
}