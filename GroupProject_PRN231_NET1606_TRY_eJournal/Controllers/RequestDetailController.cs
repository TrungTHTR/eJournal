using Application;
using Application.InterfaceService;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestDetailService _requestDetailService;
        public RequestDetailController(IRequestDetailService requestDetailService)
        {
            _requestDetailService = requestDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<RequestDetail> requestDetails = await _requestDetailService.GetAllRequestDetail();
            if (requestDetails == null)
            {
                return BadRequest();
            }
            return Ok(requestDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByReviewerId(Guid id)
        {
            List<RequestDetail> requests = await _requestDetailService.GetByReviewerId(id);
            if (requests == null)
            {
                return BadRequest();
            }
            return Ok(requests);
        }
    }
}