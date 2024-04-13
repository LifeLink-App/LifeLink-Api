using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LifeLink.Services.BaseService
{
    public static class TokenService
    {
        public static string GenerateToken(Guid userId, string username, List<Guid> roles)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                
            var keyString = configuration["Jwt:Key"] ?? throw new ArgumentException("JWT Key is not configured in the application.");
            var key = Encoding.UTF8.GetBytes(keyString);
            
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create a list of claims and add the necessary claims
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, username));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));

            // Add roles as separate claims
            foreach (var role in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }

            // Set up the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create the token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the serialized token
            return tokenHandler.WriteToken(token);
        }
    }
}
