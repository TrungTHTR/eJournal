using BusinessObject;
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

		public Article Article { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			HttpResponseMessage response = _httpClient.GetAsync($"{ApiUrl}/{id}").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				Article = JsonConvert.DeserializeObject<Article>(data);
			}
			else
			{
				return RedirectToPage("/Error");
			}
			return Page();
		}
	}
}
