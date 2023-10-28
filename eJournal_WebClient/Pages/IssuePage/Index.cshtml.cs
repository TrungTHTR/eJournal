using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Api.issueCRUD;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace eJournal_WebClient.Pages.IssuePage
{
    public class IndexModel : PageModel
    {
      /*  private readonly EJournalDBFirst.Models.EjournalDbContext _context;*/
        private HttpClient _httpClient;
        private string IssueAPIUrl;
        public IndexModel( HttpClient httpClient)
        {
           
            _httpClient = httpClient;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.Timeout = TimeSpan.FromSeconds(100);
            IssueAPIUrl = "http://localhost:5035/api/Issue";
        }

        public List<IssueViewModel> Issue { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var httpResponseData = await _httpClient.GetAsync(IssueAPIUrl);
            string strData = await httpResponseData.Content.ReadAsStringAsync();
            dynamic jsonItem= JObject.Parse(strData);
            var lst = jsonItem.item;
            Issue = ((JArray)lst).Select(x=>new IssueViewModel 
            {
                Id = (string)x["id"],
                Volumn = (string)x["volumn"],
                Description = (string)x["description"],
                DateRelease = (string)x["dateRelease"]
            }).ToList();
           
            return Page();
        }
    }
}
