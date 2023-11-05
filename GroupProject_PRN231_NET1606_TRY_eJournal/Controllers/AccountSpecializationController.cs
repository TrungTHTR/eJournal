using Application.InterfaceService;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSpecializationController : ODataController
    {
        private IAccountSpecializeService _accountSpecializationService;
        public AccountSpecializationController(IAccountSpecializeService accountSpecializationService)
        {
            _accountSpecializationService = accountSpecializationService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetAccountBySpecialize([FromQuery] string specializeName)
        {
            List<Account> accounts = await _accountSpecializationService.GetReviewerBySpecialization(specializeName);
            if (accounts.Count > 0)
            {
                return Ok(accounts);
            }
            return BadRequest();
        }
    }
}
