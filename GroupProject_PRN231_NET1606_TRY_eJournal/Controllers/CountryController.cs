using Application.InterfaceService;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
	[Route("odata")]
	public class CountryController : ODataController
	{
		private readonly ICountryService _countryService;
		public CountryController(ICountryService countryService)
		{
			_countryService = countryService;
		}
		[EnableQuery]
		[HttpGet("Countries")]
		public async Task<IActionResult> GetAllCountry()
		{
			List<Country> countries= await _countryService.GetAllCountry();
			if(countries.Count==0) return NotFound();
			return Ok(countries);
		}
	}
}
