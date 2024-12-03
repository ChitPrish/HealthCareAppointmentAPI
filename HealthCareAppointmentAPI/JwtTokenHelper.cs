using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCareAppointmentAPI
{
    public class JwtTokenHelper : IJwtTokenHelper
    {
        private const int defaultExpiryTime = 60;
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username)
        {
            if (_configuration["JwtSettings:SecretKey"] != null)
            {
                var secretKey = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                int expireTime = 0;
                bool isExpiry = int.TryParse(_configuration["JwtSettings:ExpiryInMinutes"], out expireTime);
                if (expireTime == 0)
                {
                    expireTime = defaultExpiryTime;
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expireTime),
                    Issuer = _configuration["JwtSettings:Issuer"],
                    Audience = _configuration["JwtSettings:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else
            {
                return string.Empty;
            }
            
        }
    }
}
