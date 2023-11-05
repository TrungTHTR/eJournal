using Application.InterfaceService;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestReviewController : ODataController
    {
        private readonly IRequestReviewService _requestReviewService;

        public RequestReviewController(IRequestReviewService requestReviewService)
        {
            _requestReviewService = requestReviewService;
        }

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
        public async Task<IActionResult> Post([FromBody] RequestReview requestReview)
        {
            var _requestReview = await _requestReviewService.GetRequestReviews(requestReview.Id);
            if (_requestReview == null)
            {
                return BadRequest("Request has exist");
            }
            await _requestReviewService.CreateRequestReview(requestReview);
            return NoContent();
        }
    }
}