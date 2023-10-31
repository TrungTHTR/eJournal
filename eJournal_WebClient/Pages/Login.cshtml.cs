using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eJournal_WebClient.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AuthenticationRequest AuthenRequest { get; set; } = default!;
        [BindProperty]
        public string ErrorMessage { get; set; }
        private readonly HttpClient _client;
        private string LoginUrl;
        private string LogoutUrl = "http://localhost:5035/api/Authentication/logout";

		public LoginModel(HttpClient client)
        {
            _client = client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            LoginUrl = "http://localhost:5035/api/Authentication/authentication";
        }
        public IActionResult OnGet()
        {
            return Page();
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
            else
            {
                string data = await httpResponseMessage.Content.ReadAsStringAsync();
                AuthenticationResponse? authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(data);
				//var tokenHandler = new JwtSecurityTokenHandler();
				//var jwtSecurityToken = tokenHandler.ReadJwtToken(authResponse.AccessToken);
				//var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
				//var role = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "role").Value;
				//identity.AddClaim(new Claim(ClaimTypes.Email, jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "email").Value));
				//identity.AddClaim(new Claim(ClaimTypes.Role, jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "role").Value));
				//var principal = new ClaimsPrincipal(identity);
				//await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
				//SessionHelper.SetObjectAsJson(HttpContext.Session, "jwt", customer.Token);
				//SessionHelper.SetObjectAsJson(HttpContext.Session, "refreshToken", customer.RefreshToken);
				//SessionHelper.SetObjectAsJson(HttpContext.Session, "role", role);
				if (authResponse != null)
                {
                    HttpContext.Response.Cookies.Append("AccessToken", authResponse.AccessToken);
                    Response.Cookies.Append("RefreshToken", authResponse.RefreshToken);
                }
            }
            return RedirectToPage("/Userpage/Index");
        }

        public async Task OnPostLogout()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["Access Token"]);
            HttpResponseMessage response = await _client.PostAsync(LogoutUrl, null);
            if(!response.IsSuccessStatusCode)
            {
                RedirectToPage("Error");
            }
            else
            {
                Response.Cookies.Delete("Access Token");
                Response.Cookies.Delete("Redirect Token");
                RedirectToPage("Index");
            }
        }
    }
}
