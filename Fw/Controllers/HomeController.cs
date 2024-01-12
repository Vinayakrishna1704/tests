using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Fw.utils;
using Fw.Utils;

namespace Fw.Controllers
{
    public class HomeController : Controller
	{
        
        [HttpGet]
        public ActionResult Home()
        {
            DataTable tab = new DataTable();
            using (var connection=DbUtils.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Apartment WHERE isrented=0"; 
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(tab);

            }
            List<DataRow> rows = tab.AsEnumerable().ToList<DataRow>();
            return View(rows);
        }
        [HttpPost]
        public ActionResult Home(int? bhk ,int? cost,int? floorspace)
        {
            DataTable tab = new DataTable();
            if (bhk.HasValue)
            {
                using(var connection = DbUtils.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT * FROM Apartment WHERE bhk=" + bhk.ToString();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(tab);
                }
                List<DataRow> rows = tab.AsEnumerable().ToList<DataRow>();
                return View(rows);
            }
            if (cost.HasValue)
            {
                using (var connection = DbUtils.GetConnection())
                {
                    //string query;
                    connection.Open();
                    if (cost.ToString() == "less")
                    {
                        string query2 = "SELECT * FROM Apartment WHERE cost<5000";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);


                    }

                    else if (cost.ToString()=="great")
                    {
                        string query2 = "SELECT * FROM Apartment WHERE cost>5000";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(cost.ToString()=="10")
                    {
                        string query2 = "SELECT * FROM Apartment WHERE cost BETWEEN 5000 AND 8000";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else
                    {
                        string query2 = "SELECT * FROM Apartment WHERE cost BETWEEN 8000 AND 10000";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                }
                List<DataRow> rows = tab.AsEnumerable().ToList<DataRow>();
                return View(rows);

            }
            if (floorspace.HasValue)
            {
                using (var connection = DbUtils.GetConnection())
                {
                    connection.Open();
                    if (floorspace.ToString() == "less")
                    {
                        string query3 = "SELECT * FROM Apartment WHERE floorspace<200";
                        SqlCommand command = new SqlCommand(query3, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(floorspace.ToString()=="great")
                    {
                        string query = "SELECT * FROM Apartment WHERE floor_space>400" + floorspace.ToString();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(floorspace.ToString()=="10")
                    {
                        string query = "SELECT * FROM Apartment WHERE floor_space BETWEEN 200 AND 300";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else
                    {
                        string query = "SELECT * FROM Apartment WHERE cost BETWEEN 300  AND 400";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                }
                List<DataRow> rows = tab.AsEnumerable().ToList<DataRow>();
                return View(rows);

            }
            return View();
        }
        
        [HttpGet]
		public ActionResult Index()
		{
			ViewBag.Title = "Index Page";

			return View();
		}
		public ActionResult Login()
		{
			ViewBag.Title = "Login Page";

			return View();
		}
        public ActionResult User_Page()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoginSuccess()
        {
            var username = User.GetUsername();
            var role = User.GetRole();
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Title = "Register page";
            return View();
        }

        [HttpPost]
        public ActionResult Register(string fname, string lname, string email, string phone, string password)
        {
            using (var connection = DbUtils.GetConnection())
            {
                connection.Open();

                
                string query = $"insert into dbo.users (status, modified_by, modified_at, role, first_name, last_name, email, phone_no, password) " +
                    $"values (1, 1, @value, 'user', '{fname}', '{lname}', '{email}', {phone}, '{password}');";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", DateTime.Now);
                command.ExecuteNonQuery();
            }

            return View("Login");
        }

        public ActionResult Admin_start()
        {
            DataTable dTable = new DataTable();

            using (var connection = DbUtils.GetConnection())
            {
                connection.Open();

                string query = "select * from dbo.users where role='USER'";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dTable);
            }

            List<DataRow> rows = dTable.AsEnumerable().ToList<DataRow>();

            return View(rows);
        }
	}
}
