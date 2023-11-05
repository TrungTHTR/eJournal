using Application;
using Application.InterfaceService;
using Application.ViewModels.RequestDetailViewModel;
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
            return Ok(requestDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequestDetail(CreateRequestDetailViewModel createRequestDetailViewModel)
        {
            bool isCreated= await _requestDetailService.CreateRequestDetail(createRequestDetailViewModel);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}