using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlazorAppFormBinding
{
	public class EmployeeCURD
	{
		//#region Fields
		//private static SqlConnectionConfiguration _configuration;
		//#endregion

		//#region Constructors
		//public EmployeeCURD(SqlConnectionConfiguration Configuration)
		//{
		//	_configuration = Configuration;
		//}
		//#endregion

		#region Publics
		public static void CreateEmployee(EmployeeInformation employee)
		{
			using SqlConnection con = new SqlConnection("Data Source=MS-00603;Initial Catalog=EmployeeInformation;Persist Security Info=True;User ID=sa;Password=password-123");
			const string strInsertQuery = "insert into Employee(EmployeeId, EmployeeName, Department, salary, DOB, City) values(@EmployeeId, @EmployeeName, @Department, @Salary, @DOB, @City)";
			SqlCommand cmdSql = new SqlCommand(strInsertQuery, con);
			cmdSql.Parameters.AddWithValue("@EmployeeId", Guid.NewGuid().ToString());
			cmdSql.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
			cmdSql.Parameters.AddWithValue("@Department", employee.Department);
			cmdSql.Parameters.AddWithValue("@Salary", employee.Salary);
			cmdSql.Parameters.AddWithValue("@DOB", employee.DOB.Date);
			cmdSql.Parameters.AddWithValue("@City", employee.City);

			con.Open();
			cmdSql.ExecuteNonQuery();

			con.Close();
			cmdSql.Dispose();
		}

		public static List<EmployeeInformation> FetchEmployees()
		{
			List<EmployeeInformation> lstEmployees = new List<EmployeeInformation>();
			using SqlConnection con = new SqlConnection("Data Source=MS-00603;Initial Catalog=EmployeeInformation;Persist Security Info=True;User ID=sa;Password=password-123");
			const string strSelectQuery = "select * from Employee";
			SqlCommand cmdSql = new SqlCommand(strSelectQuery, con);
			con.Open();

			SqlDataReader sqlReader = cmdSql.ExecuteReader();
			if(sqlReader.HasRows)
			{
				while(sqlReader.Read())
				{
					EmployeeInformation employee = new EmployeeInformation
					                               {
						                               EmployeeName = sqlReader["EmployeeName"].ToString(),
						                               Department = sqlReader["Department"].ToString(),
						                               Salary = Convert.ToInt32(sqlReader["salary"]),
						                               DOB = Convert.ToDateTime(sqlReader["DOB"]),
													   City = sqlReader["City"].ToString()
					                               };
					lstEmployees.Add(employee);
				}

				con.Close();
				cmdSql.Dispose();
			}

			return lstEmployees;
		}
		#endregion
	}
}