using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eJournal_WebClient.Pages.ArticlePages
{
    public class IndexModel : PageModel
    {
		private readonly HttpClient _httpClient;
		private readonly string ApiUrl = "http://localhost:5035/api/Article/unauthorized-user";

		public IndexModel()
		{
			_httpClient = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_httpClient.DefaultRequestHeaders.Accept.Add(contentType);
		}

		public IList<ArticleResponse> Articles { get; set; } = default!;

		public async Task OnGetAsync(int? id, string? title, string? status, string? authorName)
		{
			if(id != null)
			{

			}
			HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);
			string data = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			Articles = JsonSerializer.Deserialize<List<ArticleResponse>>(data, options);
		}
	}
}
