using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Api.issueCRUD;
using Newtonsoft.Json.Linq;

namespace eJournal_WebClient.Pages.IssuePage
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _client;
        private string IssueAPIUrl = "";

        public EditModel(HttpClient client)
        {
           _client= client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _client.Timeout = TimeSpan.FromSeconds(100);
            IssueAPIUrl = "http://localhost:5035/api/Issue";
        }

        [BindProperty]
        public ModifyIssue Issue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IssueId issueId = new IssueId()
            {
                Id = id.Value.ToString(),
            };
            string detailURL = $"{IssueAPIUrl}/detail";
            JsonContent content = JsonContent.Create(issueId);
            var httpResponseMessage = await _client.PostAsync(detailURL, content);
            string strData = await httpResponseMessage.Content.ReadAsStringAsync();
            dynamic jsonContent = JObject.Parse(strData);
            Issue = new ModifyIssue()
            {
                Id = jsonContent["id"].ToString(),
                Volumn = jsonContent["volumn"],
                Description = jsonContent["description"],
                DateRelease = jsonContent["dateRelease"]
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            JsonContent content= JsonContent.Create(Issue);
            var httpResponseMessage= await _client.PutAsync(IssueAPIUrl,content);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
