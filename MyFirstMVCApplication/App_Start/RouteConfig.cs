﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MyFirstMVCApplication
{
	public class RouteConfig
	{
		#region Publics
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
			                name: "Default",
			                url: "{controller}/{action}/{id}",
			                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			               );

			routes.MapRoute(
			                name: "Student",
			                url: "{controller}/{id}",
			                defaults: new { controller = "Student", action = "Index" }
			               );
		}
		#endregion
	}
}