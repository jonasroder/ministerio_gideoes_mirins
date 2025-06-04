//using Core.Authentication.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.SharedKernel.Security
{
//    public class JwtTokenGenerator : IJwtTokenGenerator
//    {
//        private readonly JwtSettings _settings;

//        public JwtTokenGenerator(IOptions<JwtSettings> options)
//            => _settings = options.Value;

//        public (string Token, DateTime Expires) Generate(User user)
//        {
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes);
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email.Value),
//                new Claim(ClaimTypes.Role,                    user.Role.ToString())
//            };

//            var token = new JwtSecurityToken(
//                issuer: _settings.Issuer,
//                audience: _settings.Audience,
//                claims: claims,
//                expires: expires,
//                signingCredentials: creds);

//            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
//        }
//    }
}
