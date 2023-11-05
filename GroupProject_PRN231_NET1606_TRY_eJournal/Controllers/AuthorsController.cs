using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ODataController
	{
		private readonly IAuthorService _authorService;

		public AuthorsController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAuthors()
		{
			return Ok(await _authorService.GetAuthors());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthor([FromRoute] Guid id)
		{
			var author = await _authorService.GetAuthor(id);
			if(author == null)
			{
				return NotFound();
			}
			return Ok(author);
		}

		[HttpGet("{id}/identityNumber")]
		public async Task<IActionResult> GetAuthorByIdentityCardNumber([FromRoute] string id)
		{
			var author = await _authorService.GetAuthor(id);
			if (author == null)
			{
				return NotFound();
			}
			return Ok(author);
		}

		[HttpPost]
		[Authorize(Roles = "Author")]
		public async Task CreateAuthor(AuthorRequest request)
		{
			await _authorService.CreateAuthor(request);
		}

		[HttpPost("register")]
		[Authorize(Roles = "User")]
		public async Task RegisterAuthor(AuthorRequest request)
		{
			await _authorService.RegisterAuthor(request);
		}
	}
}
