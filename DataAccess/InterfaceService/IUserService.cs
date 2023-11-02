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
        Task<string> Login(AuthenticationRequest request);
        Task<bool> Register(RegistrationRequest request);
        Task<Account> GetCurrentLoginUser();

	}
}
