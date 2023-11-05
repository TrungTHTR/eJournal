using Application.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ODataController
    {
        private readonly ISpecializeService _specializeService;
        public SpecializationController(ISpecializeService specializeService)
        {
            _specializeService = specializeService;
        }
        [HttpGet]
        public IActionResult GetSpecializationName()
        {
            List<string> specializationNames =  _specializeService.GetSpecializeName();
            if(specializationNames.Count== 0)
            {
                return BadRequest(new {message= "Error in fetching data" });
            }
            return Ok(specializationNames);
        }
    }
}
