using Application;
using Application.InterfaceService;
using Application.ViewModels.RequestReviewViewModel;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestReviewController : ControllerBase
    {
        private readonly IRequestReviewService _requestReviewService;

        public RequestReviewController(IRequestReviewService requestReviewService)
        {
            _requestReviewService = requestReviewService;
        }

        //Why ArticleController ???
        /*public ArticleController(IRequestReviewService requestReviewService)
        {
            _requestReviewService = requestReviewService;
        }*/

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByArticleId(Guid id)
        {
            List<RequestReview> requests = await _requestReviewService.GetByArticleId(id);
            if (requests == null)
            {
                return BadRequest();
            }
            return Ok(requests);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestReview requestReview)
        {
          int isCreated=  await _requestReviewService.CreateRequestReview(requestReview);
            if(isCreated == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}