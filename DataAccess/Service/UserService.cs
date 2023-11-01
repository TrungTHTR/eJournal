using Application.InterfaceService;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using BusinessObject;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
            _contextAccessor = contextAccessor;
        }

        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
			#region check email
			var users = await _unitOfWork.AccountRepository.GetAllAsync(filter: x => x.Email == request.Email, includedProperties: nameof(Account.Role));
            if (users == null || !users.Any())
            {
                throw new Exception("Invalid Email");
            }
			#endregion
			Account user = users.First();
			#region check password
			if (!user.PasswordHash.SequenceEqual(EncryptionUtils.Encrypt(request.Password, user.PasswordSalt)))
			{
				throw new Exception("Invalid password");
			}
			#endregion
			#region check if user logout or refresh token exprire
			string? refreshToken = user.RefreshToken;
            DateTime? expiredDate = null;
			if (!string.IsNullOrEmpty(refreshToken))
			{
                expiredDate = _jwtService.GetExpiredDate(refreshToken);
                if(expiredDate != null && expiredDate > DateTime.UtcNow)
                {
					throw new Exception("You haven't logout yet");
				}
			}
			#endregion
			string token = _jwtService.GenerateAuthenticatedAccessToken(user.Role.Rolename, user.Email, user.Id.ToString());
            refreshToken = _jwtService.GenerateAuthenticatedRefreshToken(user.Id.ToString(), DateTime.UtcNow.AddYears(1));
            user.RefreshToken = refreshToken;
            _unitOfWork.AccountRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return new AuthenticationResponse { 
                AccessToken = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthenticationResponse> RefreshToken(string refreshToken)
        {
			#region check if user is valid
			var userId = _jwtService.GetUserId(refreshToken);
			if (userId == null)
			{
				throw new Exception("Invalid refresh token");
			}
			var users = await _unitOfWork.AccountRepository.GetAllAsync(filter: x => x.Id == userId, includedProperties: nameof(Account.Role));
			if (users == null || !users.Any())
			{
				throw new Exception("User doesn't exist");
			}
			#endregion
			var user = users.First();
			#region check if refresh token is the same as one in database
			if (refreshToken != user.RefreshToken)
            {
                throw new Exception("Invalid refresh token");
            }
			#endregion
			#region check if refresh token expire
			var expiredDate = _jwtService.GetExpiredDate(refreshToken);
			if (expiredDate != null && expiredDate < DateTime.UtcNow)
			{
                user.RefreshToken = null;
                _unitOfWork.AccountRepository.Update(user);
                await _unitOfWork.SaveAsync();
				throw new Exception("Your login session is expired");
			}
			#endregion
			string token = _jwtService.GenerateAuthenticatedAccessToken(user.Role.Rolename, user.Email, user.Id.ToString());
			refreshToken = _jwtService.GenerateAuthenticatedRefreshToken(user.Id.ToString(), expiredDate ?? DateTime.UtcNow);
            user.RefreshToken = refreshToken;
			_unitOfWork.AccountRepository.Update(user);
			await _unitOfWork.SaveAsync();
			return new AuthenticationResponse
            {
                AccessToken = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<bool> Register(RegistrationRequest request)
        {
            var users = _unitOfWork.AccountRepository.GetAllAsync(x => x.Email == request.Email).Result;
            if(users != null && users.Any())
            {
                throw new Exception("This email has been registered before");
            }
            var user = _mapper.Map<Account>(request);
            await _unitOfWork.AccountRepository.AddAsync(user);
            int i = await _unitOfWork.SaveAsync();
            return i >0;
        }

        public async Task Logout()
        {
            Account user = await GetCurrentLoginUser();
            user.RefreshToken = null;
            _unitOfWork.AccountRepository.Update(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Account> GetCurrentLoginUser()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Sid)?.Value;
            if(userId == null)
            {
                throw new Exception("User hasn't logged in yet");
            }
            var user = await _unitOfWork.AccountRepository.GetAsync(Guid.Parse(userId));
            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            return user;
        }
    }
}
