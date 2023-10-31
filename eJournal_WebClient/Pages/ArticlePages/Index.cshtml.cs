using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eJournal_WebClient.Pages.ArticlePages
{
    public class IndexModel : PageModel
    {
		private readonly HttpClient _httpClient;
		private readonly string ApiUrl = "http://localhost:5035/api/Article/unauthorized-user";
		private readonly string MajorApiUrl = "http://localhost:5035/api/Majors";

		public IndexModel()
		{
			_httpClient = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_httpClient.DefaultRequestHeaders.Accept.Add(contentType);
		}

		public IList<ArticleResponse> Articles { get; set; } = default!;

		public async Task OnGetAsync(string? id, string? title, string? authorName)
		{
            #region Get articles
            StringBuilder apiUrl = new StringBuilder(ApiUrl);
            List<string> filters = new List<string>();
            if (!string.IsNullOrEmpty(id))
            {
                filters.Add($"id eq '{id}'");
            }
            if (!string.IsNullOrEmpty(title))
            {
                filters.Add($"contains(title, '{title}')");
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                filters.Add($"contains(authorName, '{authorName}')");
            }
            if (filters.Any())
            {
                apiUrl.Append("?$filter=");
                if (filters.Count > 1)
                {
                    apiUrl.Append(string.Join(" and ", filters));
                }
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);
            HttpResponseMessage response = _httpClient.GetAsync(apiUrl.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Articles = JsonConvert.DeserializeObject<IList<ArticleResponse>>(data);
            }
            else
            {
                RedirectToPage("/Error");
            }
            #endregion
            #region Get majors
            HttpResponseMessage response2 = _httpClient.GetAsync(MajorApiUrl).Result;
            if (response2.IsSuccessStatusCode)
            {

            }
            #endregion
        }
    }
}
