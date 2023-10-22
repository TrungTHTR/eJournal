using Grpc.Net.Client;
using API.issueCRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API_gRPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly GrpcChannel _channel;
        private readonly IssueCRUD.IssueCRUDClient _client;
        private IMapper _mapper;
        public IssueController() 
        {
         _channel = GrpcChannel.ForAddress("https://localhost:7096");
            _client= new IssueCRUD.IssueCRUDClient(_channel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIssue()
        {
            var response =  _client.GetAllIssue(new Empty { });
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateIssue(AddIssue addIssue)
        {
            var response= _client.CreateIssue(addIssue);
            if(response.IsTrue)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
