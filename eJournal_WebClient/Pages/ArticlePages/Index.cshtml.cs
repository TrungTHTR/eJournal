using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using eJournal_WebClient.Common;

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

		public async Task<IActionResult> OnGetAsync(string? id, string? title, string? authorName)
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
                else
                {
                    apiUrl.Append(filters.First());
                }
            }
            _httpClient.AddAuthorizationHeader(HttpContext);
            HttpResponseMessage response = _httpClient.GetAsync(apiUrl.ToString()).Result; //response.Headers.WwwAuthenticate
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Articles = JsonConvert.DeserializeObject<IList<ArticleResponse>>(data);
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate.ToString().Contains("Bearer error=\"invalid_token\", error_description=\"The token expired at"))
                {
                    var renewTokenStatus = await _httpClient.RenewAccessToken(HttpContext);
                    if (renewTokenStatus)
                    {
                        return RedirectToPage("./Index");
                    }
                }
                return RedirectToPage("/Error");
            }
            #endregion
            #region Get majors
            HttpResponseMessage response2 = _httpClient.GetAsync(MajorApiUrl).Result;
            if (response2.IsSuccessStatusCode)
            {

            }
            #endregion
            return Page();
        }
    }
}
