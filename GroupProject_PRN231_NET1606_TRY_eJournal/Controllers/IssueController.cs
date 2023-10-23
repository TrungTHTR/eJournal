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
        public async Task<IActionResult> CreateIssue(AddIssue addIssue)
        {
            var response = _client.CreateIssue(addIssue);
            if (response.IsTrue)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateIssue(ModifyIssue modifyIssue)
        {
            var response = _client.UpdateIssue(modifyIssue);
            if (response.IsTrue)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
