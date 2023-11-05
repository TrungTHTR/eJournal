using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ODataController
    {
        private readonly IMajorService _majorService;

		public MajorsController(IMajorService majorService)
		{
			_majorService = majorService;
		}

		[HttpGet]
        [EnableQuery]
        public async Task<ActionResult<MajorDTO>> GetMajors()
        {
            return Ok(await _majorService.GetAll());
        }
    }
}
