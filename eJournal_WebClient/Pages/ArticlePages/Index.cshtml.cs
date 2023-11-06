using Application.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using eJournal_WebClient.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eJournal_WebClient.Pages.ArticlePages
{
    public class IndexModel : PageModel
    {
		private readonly HttpClient _httpClient;
		private readonly string ApiUrl = "http://localhost:5035/api/Article/unauthorized-user";
		private readonly string TopicApiUrl = "http://localhost:5035/api/Topics";

		public IndexModel()
		{
			_httpClient = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_httpClient.DefaultRequestHeaders.Accept.Add(contentType);
		}

		public IList<ArticleResponse> Articles { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string? id, string? title, string? authorName, int? topic)
		{
			#region Get articles
			#region article filter
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
			if (topic != null && topic != 0)
			{
				filters.Add($"topic/topicId eq {topic}");
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
			#endregion
			HttpResponseMessage response = _httpClient.GetAsync(apiUrl.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Articles = JsonConvert.DeserializeObject<IList<ArticleResponse>>(data);
            }
            else
            {
                return RedirectToPage("/Error");
            }
			#endregion
			#region Get topics
			var topics = await GetTopics();
			ViewData["Topic"] = new SelectList(topics, "TopicId", "TopicName");
			#endregion
			return Page();
        }

		private async Task<IList<TopicResponse>> GetTopics()
		{
			HttpResponseMessage response = await _httpClient.GetAsync(TopicApiUrl);
			string data = await response.Content.ReadAsStringAsync();
			var list = JsonConvert.DeserializeObject<IList<TopicResponse>>(data);
			return list;
		}
	}
}
