﻿using Application.InterfaceService;
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

        public async Task<List<UserViewAllModel>> ListAll()
        {
            return await _unitOfWork.AccountRepository.GetAllWithViewModel();
        }

        public async Task<string> Login(AuthenticationRequest request)
        {
        
            var users = await _unitOfWork.AccountRepository.GetAllAsync(filter: x => x.Email == request.Email, includedProperties: nameof(Account.Role));
            if (users == null || !users.Any())
            {
                throw new Exception("Invalid Email");
            }
            Account user = users.First();
            if (!user.PasswordHash.SequenceEqual(EncryptionUtils.Encrypt(request.Password, user.PasswordSalt)))
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

        public async Task<Account> GetCurrentLoginUser()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Sid)?.Value;
            if(userId == null)
            {
                throw new Exception("User hasn't logged in yet");
            }
            var user = await _unitOfWork.AccountRepository.GetByIdAsync(new Guid(userId));
            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            return user;
        }

		public async Task<List<Account>> ListAllReviewer()
		{
			return (List<Account>)await _unitOfWork.AccountRepository.GetAllAsync(filter:x=>x.RoleId==3);
		}
	}
}
