using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Etqaan.Application.Helpers
{
    public static class JWTHelper
    {
        private static readonly string SecretKey = "lG0rDWELYD0jPtoLNlc/sMVREJMh8laXd5bvVEZzUeg=";
        private static readonly byte[] SecretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);

        public static string GenerateToken(string userId, string userName, string[] roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),

                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            foreach (var role in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Set clock skew to zero for the token to expire exactly at the expiration time
                }, out _);

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}

