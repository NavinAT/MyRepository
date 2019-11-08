using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MutualFundAPI
{
	public class NavMutualFund
	{
		#region Publics
		public static async Task<ResponseFromLufthansa> GetAccessToken(LufthansaAccessToken searchCriteria)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			HttpClient client = new HttpClient { BaseAddress = new Uri("https://api.lufthansa.com") };
			HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth/token");

			string strrequestContent =
				$"client_id={searchCriteria.ClientId}&client_secret={searchCriteria.ClientSecret}&grant_type={searchCriteria.GrantType}";

			StringContent _content = new StringContent(strrequestContent);
			_content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
			httpRequest.Content = _content;

			HttpResponseMessage httpResponse = await client.SendAsync(httpRequest).ConfigureAwait(false);

			string _responsedata = httpResponse.Content == null ? null : await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
			ResponseFromLufthansa _result = JsonConvert.DeserializeObject<ResponseFromLufthansa>(_responsedata);

			return _result;
		}
		#endregion

		#region Privates
		private static void Main(string[] args)
		{
		}
		#endregion
	}

	public class LufthansaAccessToken
	{
		#region Properties
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string GrantType { get; set; }
		#endregion
	}

	public class ResponseFromLufthansa
	{
		#region Properties
		[JsonProperty("access_token", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
		public string AccessToken { get; set; }

		[JsonProperty("token_type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
		public string TokenType { get; set; }
		#endregion
	}
}