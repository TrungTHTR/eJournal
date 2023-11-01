using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IJwtService
    {
        string GenerateAuthenticatedAccessToken(string role, string email, string id);
		string GenerateAuthenticatedRefreshToken(string id, DateTime expiredDate);
		DateTime? GetExpiredDate(string token);
		Guid? GetUserId(string token);
		bool VerifyToken(string token);
	}
}
