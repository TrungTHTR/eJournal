using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EJournalDBFirst.Models;
using System.Net.Http.Headers;
using Api.issueCRUD;

namespace eJournal_WebClient.Pages.IssuePage
{
    public class CreateModel : PageModel
    {

        private HttpClient _client;
        private string IssueAPIUrl;
        public CreateModel(HttpClient client)
        {
            _client = client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _client.Timeout = TimeSpan.FromSeconds(100);
            IssueAPIUrl = "http://localhost:5035/api/Issue";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddIssue Issue { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
         /* if (!ModelState.IsValid || _context.Issues == null || Issue == null)
            {
                return Page();
            }

            _context.Issues.Add(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
         JsonContent content= JsonContent.Create(Issue);
            var httpResponseMessage= await _client.PostAsync(IssueAPIUrl, content); 
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
