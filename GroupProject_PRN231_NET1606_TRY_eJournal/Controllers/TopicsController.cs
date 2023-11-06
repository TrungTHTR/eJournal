using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TopicsController : ODataController
	{
		private readonly ITopicService _topicService;

		public TopicsController(ITopicService topicService)
		{
			_topicService = topicService;
		}

		[HttpGet]
		[EnableQuery]
		public async Task<ActionResult<IEnumerable<TopicResponse>>> Get()
		{
			return Ok(await _topicService.GetTopics());
		}
	}
}
