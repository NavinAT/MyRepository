using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmployeeService.Models;

namespace EmployeeService.Controllers
{
	public class EmployeesController : ApiController
	{
		#region Publics
		public IEnumerable<Employee> GetEmployees()
		{
			using(EmployeeDBContext employeeDb = new EmployeeDBContext())
			{
				return employeeDb.Employees.ToList();
			}
		}

		public Employee GetEmployee(int nId)
		{
			using(EmployeeDBContext employeeDb = new EmployeeDBContext())
			{
				return employeeDb.Employees.FirstOrDefault(row => row.ID == nId);
			}
		}
		#endregion
	}
}