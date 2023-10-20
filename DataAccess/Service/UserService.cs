using Application.InterfaceService;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> Login(AuthenticationRequest request)
        {
            var users = await _unitOfWork.GetRepository<Account>().GetAllAsync(x => x.Email.Equals(request.Email) && x.PasswordHash.Equals(EncryptionUtils.Encrypt(request.Password, x.PasswordSalt)));
            var user = users.FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Invalid Email or Password");
            }
            var token = _jwtService.GenerateAuthenticatedCustomerToken(user.RoleId.ToString(), user.Email, user.Id.ToString());
            return token;
        }

    }
}
