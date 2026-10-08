using Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Service
{
    public class JwtTokenGenerator
    {
        private readonly string secretKey;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            this.secretKey = configuration["AuthSettings:SecretKey"];
        }

        public string GenerateJwtToken(AppUser user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("FirstName", user.FirstName),
                    new Claim("Id",user.Id),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,String.Join(",", roles))
                }),

                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
