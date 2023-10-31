using Application.ViewModels.UserViewModels;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IUserService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<bool> Register(RegistrationRequest request);
        Task Logout();
		Task<Account> GetCurrentLoginUser();

	}
}
