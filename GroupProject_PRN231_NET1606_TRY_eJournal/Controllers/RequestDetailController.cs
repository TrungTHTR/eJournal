using Application.InterfaceService;
using Application.ViewModels.RequestDetailViewModels;
/*using Application.ViewModels.RequestReviewViewModels;*/
using BusinessObject;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ODataController
    {
        private readonly IRequestDetailService _requestDetailService;
        public RequestDetailController(IRequestDetailService requestDetailService)
        {
            _requestDetailService = requestDetailService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            List<RequestDetail> requestDetails = await _requestDetailService.GetAllRequestDetail();
            if (requestDetails == null)
            {
                return BadRequest();
            }
            return Ok(requestDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequestDetail(CreateRequestDetailViewModel createRequestDetailViewModel)
        {
            bool isCreated = await _requestDetailService.CreateRequestDetail(createRequestDetailViewModel);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest("Error when creating detail");
        }
        [HttpGet("reviewer/{id}")]
        public async Task<IActionResult> GetByReviewerId(Guid id)
        {
            List<RequestDetail> requests = await _requestDetailService.GetByReviewerId(id);
            if (requests == null)
            {
                return BadRequest();
            }
            return Ok(requests);
        }

      /*  [HttpPost]
        //[Authorize("Staff")]
        public async Task<IActionResult> Create([FromBody] CreateRequestDetailViewModel request)
        {
            await _requestDetailService.Create(request);
            return Ok();
        }*/

        [HttpPut("{id}/status")]
        public async Task ChangeRequestDetailsStatus([FromRoute] Guid id, [FromQuery] RequestDetailStatus status)
        {
            await _requestDetailService.ChangeRequestStatus(id, status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestStatus(Guid id, [FromBody] StatusUpdate statusUpdate)
        {
            var _request = await _requestDetailService.GetRequestDetails(id);
            if (_request == null)
            {
                return BadRequest("Request is not found");
            }
            _request.Status = statusUpdate.Status;
            await _requestDetailService.UpdateRequestDetail(_request);
            return Ok(_request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleStatus(Guid id)
        {
            var _request = await _requestDetailService.GetRequestDetails(id);
            if (_request == null)
            {
                return BadRequest("Request is not found");
            }
            var statusModel = new RequestViewStatus
            {
                Status = _request.Status,
                Description = _request.Description,
            };
            return Ok(statusModel);
        }
    }
}