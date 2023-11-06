using Application.ViewModels.ArticleViewModels;
using Application.ViewModels.UserViewModels;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using eJournal_WebClient.Common;

namespace eJournal_WebClient.Pages.UserArticlePages
{
    public class CreateModel : PageModel
    {
        private HttpClient _httpClient;
        private string ApiUrl = "http://localhost:5035/api/Article";
        private string TopicApiUrl = "http://localhost:5035/api/Topics";
        private string AuthorApiUrl = "http://localhost:5035/api/Authors";

		public CreateModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
		}
		public async Task<IActionResult> OnGetAsync()
        {
            var topics = await GetTopics();
			ViewData["Topics"] = new SelectList(topics, "TopicId", "TopicName");
            var authors = await GetAuthors();
			ViewData["Authors"] = new SelectList(authors, "Id", "IdentityCardNumber");
			return Page();
        }

        [BindProperty]
        public ArticleRequest Article { get; set; } = default!;
        [BindProperty]
        public IFormFile? ArticleFile { get; set; }
        [BindProperty]
        public string? ErrorMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            JsonContent content = JsonContent.Create(Article);
            _httpClient.AddAuthorizationHeader(HttpContext);
            var response = await _httpClient.PostAsync(ApiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            } else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized && 
                response.Headers.WwwAuthenticate.ToString() == "Bearer error=\"invalid_token\", error_description=\"The token expired at" &&
                await _httpClient.RenewAccessToken(HttpContext))
            {
                return RedirectToAction("OnPostAsync", "CreateModel");
            }
            ErrorMessage = await response.Content.ReadAsStringAsync();
            return Page();
        }

        private async Task<IList<TopicResponse>> GetTopics()
        {
			HttpResponseMessage response = await _httpClient.GetAsync(TopicApiUrl);
			string data = await response.Content.ReadAsStringAsync();
			var list = JsonConvert.DeserializeObject<IList<TopicResponse>>(data);
            return list;
		}

        private async Task<IList<AuthorResponse>> GetAuthors()
        {
			HttpResponseMessage response = await _httpClient.GetAsync(AuthorApiUrl);
			string data = await response.Content.ReadAsStringAsync();
			var list = JsonConvert.DeserializeObject<IList<AuthorResponse>>(data);
            return list;
		}
    }
}
