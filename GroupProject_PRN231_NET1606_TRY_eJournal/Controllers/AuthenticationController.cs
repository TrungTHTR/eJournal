using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<string>> Login(AuthenticationRequest request)
        {
            var token = await _userService.Login(request);
            return Ok(token);
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            await _userService.Register(request);
            return Ok();
        }
    }
}
