using Application.InterfaceService;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using BusinessObject;
using Application.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<List<UserViewAllModel>> ListAll()
        {
            return await _unitOfWork.AccountRepository.GetAllWithViewModel();
        }

        public async Task<string> Login(AuthenticationRequest request)
        {
            var user =  _unitOfWork.AccountRepository.GetAllAsync(x=>x.Role).Result.SingleOrDefault(x=>x.Email==request.Email);
            if (user == null)
            {
                throw new Exception("Invalid Email");
            }
  
            if(!user.PasswordHash.SequenceEqual(EncryptionUtils.Encrypt(request.Password, user.PasswordSalt)))
            {
                throw new Exception("Invalid password");
            }
            var token = _jwtService.GenerateAuthenticatedCustomerToken(user.Role.Rolename, user.Email, user.Id.ToString());
            return token;
        }

        public async Task<bool> Register(RegistrationRequest request)
        {
            var users = _unitOfWork.AccountRepository.GetAllAsync().Result.SingleOrDefault(x=>x.Email==request.Email);
            if(users != null)
            {
                throw new Exception("This email has been registered before");
            }
            var user = _mapper.Map<Account>(request);
            user.RoleId = 5;
            user.IsDelete=false;
            await _unitOfWork.AccountRepository.AddAsync(user);
            int i = await _unitOfWork.SaveAsync();
            return i >0;
        }
    }
}
