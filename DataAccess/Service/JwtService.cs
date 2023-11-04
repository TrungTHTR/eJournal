using Application.InterfaceService;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using Application.Utils;
using Newtonsoft.Json.Linq;

namespace Application.Service
{
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAuthenticatedAccessToken(string role, string email, string id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, id),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                //Expires = DateTime.UtcNow.AddDays(1),
				Issuer = _configuration["jwt:issuer"],
                Audience = _configuration["jwt:audience"]

			};
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

		public string GenerateAuthenticatedRefreshToken(string id, DateTime expiredDate)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Sid, id),
			};
            var token = new JwtSecurityToken(
                signingCredentials: credentials, 
                expires: expiredDate,
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

        /// <summary>
        /// verify if token is validated jwt token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Return true if token valid, false otherwise</returns>
		public bool VerifyToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
            // is valid credentials, is token expired
			var claimPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"])),
				ValidateLifetime = true,
				ValidateAudience = false,
				ValidateIssuer = false,
				ClockSkew = TimeSpan.Zero
			}, out SecurityToken validatedToken);
            // is valid security algorithm
            if(validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                if(jwtSecurityToken.Header.Alg != SecurityAlgorithms.HmacSha512)
                {
                    return false;
                }
            }
			return true;
		}

        public DateTime? GetExpiredDate(string token)
        {
            var claims = GetClaims(token);
			var unixExpiredDate = claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;
			if (unixExpiredDate != null)
			{
                return DateTimeUtils.ConvertUnixTimeToUtcDateTime(long.Parse(unixExpiredDate));
			}
            return null;
		}

        public Guid? GetUserId(string token)
        {
			var claims = GetClaims(token);
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
            if(userId != null)
            {
                return Guid.Parse(userId);
            }
            return null;
		}

        private IEnumerable<Claim> GetClaims(string token)
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			// is valid credentials, is token expired
			var claimPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"])),
				ValidateLifetime = false,
				ValidateAudience = false,
				ValidateIssuer = false,
				ClockSkew = TimeSpan.Zero
			}, out SecurityToken validatedToken);
            return claimPrincipal.Claims;
		}
	}
}
