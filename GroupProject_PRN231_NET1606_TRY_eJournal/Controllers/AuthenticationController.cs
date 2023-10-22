using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ODataController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<string>> Login(AuthenticationRequest request)
        {
            return Ok(await _userService.Login(request));
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            await _userService.Register(request);
            return Ok();
        }
    }
}
