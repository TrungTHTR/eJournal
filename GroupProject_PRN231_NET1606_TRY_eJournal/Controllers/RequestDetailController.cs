using BusinessObject;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using AutoMapper;
using Application.Service;
using Microsoft.AspNetCore.OData.Routing.Attributes;

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
            }
            return Ok(statusModel);
        }
    }
}