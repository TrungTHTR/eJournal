using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    
    public class AuthenticationController : ODataController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            await _userService.Register(request);
            return Ok();
        }

		[HttpPost("logout")]
        [Authorize]
		public async Task<ActionResult> Logout()
		{
            await _userService.Logout();
			return Ok();
		}

		[HttpPost("refresh-access-token")]
        public async Task<ActionResult<AuthenticationResponse>> RefreshAccessToken(string refreshToken)
        {
            var result = await _userService.RefreshToken(refreshToken);
            return Ok(result);
        }
    }
}
