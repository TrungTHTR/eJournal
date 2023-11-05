using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace eJournal_WebClient.Pages.ArticlePages
{
    public class DetailsModel : PageModel
    {
		private readonly HttpClient _httpClient;
		private readonly string ApiUrl = "http://localhost:5035/api/Article";

		public DetailsModel()
		{
			_httpClient = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_httpClient.DefaultRequestHeaders.Accept.Add(contentType);
		}

		public ArticleResponse Article { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			HttpResponseMessage response = await _httpClient.GetAsync($"{ApiUrl}/{id}");
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				Article = JsonConvert.DeserializeObject<ArticleResponse>(data);
			}
			else
			{
				return RedirectToPage("/Error");
			}
			return Page();
		}
	}
}
