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
        public ActionResult Home()
        {
            
           return View();
        }
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

<<<<<<< HEAD
                string query = $"insert into dbo.users (status, modified_by, modified_at, role, user_name, email, phone_no, password) " +
                    $"values (1, 1, @value, 'USER', '{fname}', '{email}', {phone}, '{password}');";
=======
                string query = $"insert into dbo.users (status, modified_by, modified_at, role, first_name, last_name, email, phone_no, password) " +
                    $"values (1, 1, @value, 'user', '{fname}', '{lname}', '{email}', {phone}, '{password}');";
>>>>>>> c8082b174dd0891f79096c14fa18d9fd12db905d

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

                string query = "select * from dbo.users where role='user'";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dTable);
            }

            List<DataRow> rows = dTable.AsEnumerable().ToList<DataRow>();

            return View(rows);
        }
	}
}
