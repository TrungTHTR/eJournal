using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Route("odata")]*/
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
            AuthenticationResponse response;
            try
            {
               response = await _userService.Login(request);
            } catch(Exception ex)
            {
                return BadRequest(new  { ex.Message});
            }
          
            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            try
            {
                await _userService.Register(request);
            } catch(Exception ex)
            {
                return BadRequest(new  { ex.Message });
            }
           
            return Ok();
        }
        [HttpGet("Reviewer")]
        public async Task<IActionResult> GetAllReviewer()
        {
            List<Account> listReviewer= await _userService.ListAllReviewer();
            return Ok(listReviewer);
        }
        /*[EnableQuery]
        [HttpGet("Users")]
        public async Task<ActionResult> Get() 
        { 
            List<UserViewAllModel> users= await _userService.ListAll();
            return Ok(users);
        }*/

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
