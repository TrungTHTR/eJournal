using Application.ViewModels.UserViewModels;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Net.Http.Headers;

namespace eJournal_WebClient.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegistrationRequest RegistrationRequest { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        private HttpClient _client;
        private string CountryAPIUrl;
        private string RegisterAPIUrl;
        public RegisterModel(HttpClient client)
        {
            _client= client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            CountryAPIUrl = "http://localhost:5035/odata/Countries";
            RegisterAPIUrl = "http://localhost:5035/api/Authentication/registration";
        }
        public async Task<IActionResult> OnGet()
        {
            var httpResponseMessage= await _client.GetAsync(CountryAPIUrl);
            string productionData = await httpResponseMessage.Content.ReadAsStringAsync();
            dynamic jsonContent = JObject.Parse(productionData);
            var lstData = jsonContent.value;
            if (lstData != null)
            {
                List<Country> countries=((JArray)lstData).Select(x=>new Country
                {
                    CountryId = (int)x["CountryId"],
                    CountryName = (string)x["CountryName"]
                }).ToList();
                ViewData["CountryId"] = new SelectList(countries, "CountryId", "CountryName");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            JsonContent jsonContent = JsonContent.Create(RegistrationRequest);
            var httpResponseMessage= await _client.PostAsync(RegisterAPIUrl, jsonContent);
            if(!httpResponseMessage.IsSuccessStatusCode)
            {
                ErrorMessage=await httpResponseMessage.Content.ReadAsStringAsync();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
