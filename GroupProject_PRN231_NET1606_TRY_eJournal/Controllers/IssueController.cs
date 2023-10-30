using Application.InterfaceService;
using BusinessObject;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.issueCRUD;
namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly GrpcChannel _channel;
        private readonly IssueCRUD.IssueCRUDClient _client;
       
        public IssueController()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:7096");
            _client = new IssueCRUD.IssueCRUDClient(_channel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIssue()
        {
            var response = _client.GetAllIssue(new Empty { });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody]AddIssue addIssue)
        {
            try
            {
                var response = _client.CreateIssue(addIssue);
                if (response.IsTrue)
                {
                    return Ok();
                }
            } catch(Exception ex)
            {
                return BadRequest("String must be in dd/MM/yyyy format");
            }
           
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateIssue([FromBody]ModifyIssue modifyIssue)
        {
            try 
            {
                var response = _client.UpdateIssue(modifyIssue);
                if (response.IsTrue)
                {
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return BadRequest("String must be in dd/MM/yyyy format");
            }
           
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult RemoveIssue([FromBody] IssueId issueId)
        {
            var response= _client.DeleteIssue(issueId);
            if (response.IsTrue)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost("detail")]
        public IActionResult GetIssueById([FromBody]IssueId issueId)
        {
            var response= _client.GetIssueById(issueId);
            return Ok(response);
        }
    }
}
