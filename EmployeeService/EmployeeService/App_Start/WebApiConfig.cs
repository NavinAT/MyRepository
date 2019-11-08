using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.OAuth;
using RouteParameter = System.Web.Http.RouteParameter;

namespace EmployeeService
{
	public static class WebApiConfig
	{
		#region Publics
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
			config.Formatters.Add(new CustomJsonFormatter());

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
			                           name: "DefaultApi",
			                           routeTemplate: "api/Employee/{controller}/{id}",
			                           defaults: new { id = RouteParameter.Optional }
			                          );
		}

		private class CustomJsonFormatter : JsonMediaTypeFormatter
		{
			public CustomJsonFormatter()
			{
				this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			}

			public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
			{
				base.SetDefaultContentHeaders(type, headers, mediaType);
				headers.ContentType = new MediaTypeHeaderValue("application/json");
			}
		}
		#endregion
	}
}