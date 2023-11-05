using Application.ViewModels.ArticleViewModels;
using Application.ViewModels.RequestReviewViewModel;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eJournal_WebClient.Pages.StaffPage
{
    public class RequestModel : PageModel
    {
        [BindProperty]
        public CreateRequestReview CreateRequestReview { get; set; }
        [BindProperty]
        public List<string> Specializations { get; set; }
        [BindProperty]
        public string SelectedSpecialization { get; set; }
        [BindProperty]
        public List<Account> Accounts { get; set; }
        private readonly HttpClient _client;
        private string ArticleAPI;
        private string RequestUrl;
        private string SpecializationAPI;
        private string AccountSpecializationAPI;
        public RequestModel(HttpClient client)
        {
            _client= client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ArticleAPI = "http://localhost:5035/api/Article";
            RequestUrl = "http://localhost:5035/api/RequestReview";
            SpecializationAPI = "http://localhost:5035/api/Specialization";
            AccountSpecializationAPI = "http://localhost:5035/api/AccountSpecialization";
        }
        public async Task<IActionResult> OnGet()
        {
            string draftedArticle = $"{ArticleAPI}/draft";
            var httpSpecializeResponse=await _client.GetAsync(SpecializationAPI);
            var httpArticleResponse=await _client.GetAsync(draftedArticle);
            string articleData= await httpArticleResponse.Content.ReadAsStringAsync();
            string specializeData = await httpSpecializeResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Specializations = JsonSerializer.Deserialize<List<string>>(specializeData, options);
            List<ArticleResponse> articles=JsonSerializer.Deserialize<List<ArticleResponse>>(articleData, options);
            ViewData["ArticleId"] = new SelectList(articles, "Id", "Title");
            ViewData["SpecializeName"] = new SelectList(Specializations);
            
            return Page();
        }
        public async Task<IActionResult> OnPostFilter(string specializeName)
        {
            specializeName = SelectedSpecialization;
            string reviewer = $"{AccountSpecializationAPI}/search?specializeName={specializeName}";
            var httpResposeMessage = await _client.GetAsync(reviewer);
            
            string strData= await httpResposeMessage.Content.ReadAsStringAsync() ;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Accounts = JsonSerializer.Deserialize<List<Account>>(strData, options);
            string draftedArticle = $"{ArticleAPI}/draft";
            var httpSpecializeResponse = await _client.GetAsync(SpecializationAPI);
            var httpArticleResponse = await _client.GetAsync(draftedArticle);
            string articleData = await httpArticleResponse.Content.ReadAsStringAsync();
            string specializeData = await httpSpecializeResponse.Content.ReadAsStringAsync();
            Specializations = JsonSerializer.Deserialize<List<string>>(specializeData, options);
            List<ArticleResponse> articles = JsonSerializer.Deserialize<List<ArticleResponse>>(articleData, options);
            ViewData["ArticleId"] = new SelectList(articles, "Id", "Title");
            ViewData["SpecializeName"] = new SelectList(Specializations);
            return Page();
        }
        public Task<IActionResult> OnPostSendRequest()
        {

        }
    }
}
