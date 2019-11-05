using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

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

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
			                           name: "DefaultApi",
			                           routeTemplate: "api/Employee/{controller}/{id}",
			                           defaults: new { id = RouteParameter.Optional }
			                          );
		}
		#endregion
	}
}