using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;

namespace eJournal_WebClient.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AuthenticationRequest AuthenRequest { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        private readonly HttpClient _client;
        private string LoginUrl;
        public LoginModel(HttpClient client)
        {
            _client = client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            LoginUrl = "http://localhost:5035/api/Authentication/authentication";
        }
       public async Task<IActionResult> OnPost()
        {
            JsonContent jsonContent = JsonContent.Create(AuthenRequest);
            var httpResponseMessage= await _client.PostAsync(LoginUrl, jsonContent);
            if(!httpResponseMessage.IsSuccessStatusCode) 
            {
                ErrorMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                return Page();
            }
            return RedirectToPage("/Userpage/Index");
        }
    }
}
