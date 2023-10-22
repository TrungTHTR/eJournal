using Application.ViewModels.UserViewModels;
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
        Task Register(RegistrationRequest request);
    }
}
