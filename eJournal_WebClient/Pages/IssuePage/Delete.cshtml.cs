using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Api.issueCRUD;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace eJournal_WebClient.Pages.IssuePage
{
    public class DeleteModel : PageModel
    {
        
        private HttpClient _client;
        private string IssueAPIUrl = "";
        public DeleteModel( HttpClient client)
        {
           
            _client = client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _client.Timeout = TimeSpan.FromSeconds(100);
            IssueAPIUrl = "http://localhost:5035/api/Issue";
        }

        [BindProperty]
      public IssueViewModel Issue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            IssueId issueId=new IssueId()
            {
                Id=id.Value.ToString(),
            };
            string detailURL = $"{IssueAPIUrl}/detail";
            JsonContent content=JsonContent.Create(issueId);
            var httpResponseMessage = await _client.PostAsync(detailURL,content);
            string strData= await httpResponseMessage.Content.ReadAsStringAsync();
            dynamic jsonContent = JObject.Parse(strData);
            Issue = new IssueViewModel()
            {
                Id = jsonContent["id"].ToString(),
                Volumn = jsonContent["volumn"],
                Description= jsonContent["description"],
                DateRelease = jsonContent["dateRelease"]
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            IssueId issueId = new IssueId()
            {
                Id = id.Value.ToString(),
            };
            JsonContent content = JsonContent.Create(issueId);
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                Content = content,
                RequestUri = new Uri(IssueAPIUrl)
            };
            var httpResponseMessage= await _client.SendAsync(request);
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
