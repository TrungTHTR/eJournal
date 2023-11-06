using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OData.ModelBuilder;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text.Json;

namespace eJournal_WebClient.Pages.StaffPage
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Account> ReviewerList { get; set; }
        private HttpClient _client;
        private IHttpContextAccessor _contextAccessor;
        private string ReviewAPIUrl = "";
        public IndexModel(HttpClient client,IHttpContextAccessor contextAccessor)
        {
            _client=client;
            _contextAccessor=contextAccessor;
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_client.DefaultRequestHeaders.Accept.Add(contentType);
            ReviewAPIUrl = "http://localhost:5035/api/Authentication/Reviewer";
		}
        public async Task<IActionResult> OnGet()
        {
            var httpResponseMessage= await _client.GetAsync(ReviewAPIUrl);
            string strData= await httpResponseMessage.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
			/*dynamic jsonData = JObject.Parse(strData);
            var jsonValueData = jsonData.value;*/
			/* if(jsonValueData != null)
             {
                 ReviewerList = ((JArray)jsonValueData).Select(x => new Account
                 {
                     Id = (Guid)x["Id"],
                     Address = (string)x["Address"],
                     Affiliation = (string)x["Affiliation"],
                     CreationDate = (DateTime)x["CreationDate"],
                     Email = (string)x["Email"],
                     UserName = (string)x["UserName"],
                     PhoneNumber = (string)x["PhoneNumber"]
                 }).ToList();*/
			ReviewerList = JsonSerializer.Deserialize<List<Account>>(strData,options);
                return Page();

            }
          
        }
       
    }

