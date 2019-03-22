using System.Web.Mvc;
using MyFirstMVCApplication.Models;

namespace MyFirstMVCApplication.Controllers
{
	public class StudentController : Controller
	{
		#region Fields
		private Student objStudent = new Student { StudentName = "Ramesh", StudentId = 08, Age = 25 };
		#endregion

		#region Publics
		// GET: Student
		public ActionResult Index()
		{
			return View(objStudent);
		}

		public ActionResult Edit(int id)
		{
			return View(objStudent);
		}

		[HttpPost]
		public ActionResult Edit(Student student)
		{
			objStudent.StudentName = student.StudentName;
			objStudent.Age = student.Age;
			objStudent.StudentId = 18;

			return RedirectToActionPermanent("Index", objStudent);
		}
		#endregion
	}
}