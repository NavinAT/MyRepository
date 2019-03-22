using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
	public class HomeController : Controller
	{
		#region Publics
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(int selectedTab)
		{
			this.ViewBag.SelectedTab = selectedTab;
			return View();
		}

		public ActionResult About()
		{
			this.ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			this.ViewBag.Message = "Your contact page.";

			return View();
		}
		#endregion
	}
}