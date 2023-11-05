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
        public async Task<ActionResult<string>> Login(AuthenticationRequest request)
        {
            string token;
            try
            {
                 token = await _userService.Login(request);
            } catch(Exception ex)
            {
                return BadRequest(new  { ex.Message});
            }
            return Ok(token);
            
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
    }
}
