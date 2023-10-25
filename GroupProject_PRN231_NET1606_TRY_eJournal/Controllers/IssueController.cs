using Application.InterfaceService;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Issue> issues= await _issueService.GetAll();
            return Ok(issues);  
        }
    }
}
