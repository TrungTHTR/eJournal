using Application.ViewModels.UserViewModels;
using Azure;
using Azure.Core;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eJournal_WebClient.Common
{
	public static class AuthorizationFilter
	{
		public static void AddAuthorizationHeader(this HttpClient client, HttpContext httpContext)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Request.Cookies["AccessToken"]);
		}

		public static async Task<bool> RenewAccessToken(this HttpClient client, HttpContext httpContext)
		{
			var response = await client.PostAsJsonAsync("http://localhost:5035/api/Authentication/refresh-access-token", JsonContent.Create(httpContext.Request.Cookies["RefreshToken"]));
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				AuthenticationResponse? authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(data);
				if (authResponse != null)
				{
					httpContext.Response.Cookies.Delete("AccessToken");
					httpContext.Response.Cookies.Delete("RefreshToken");
					httpContext.Response.Cookies.Append("AccessToken", authResponse.AccessToken);
					httpContext.Response.Cookies.Append("RefreshToken", authResponse.RefreshToken);
					return true;
				}
			}
			return false;
		}
	}
}