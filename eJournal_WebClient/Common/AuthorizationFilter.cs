using Azure.Core;
using System.Net.Http.Headers;

namespace eJournal_WebClient.Common
{
	public static class AuthorizationFilter
	{
		public static void AddAuthorizationHeader(this HttpClient client, HttpContext httpContext)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Request.Cookies["AccessToken"]);
		}

		public static void RenewAccessToken(this HttpClient client)
		{

		}
	}
}