using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
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

                string query = $"insert into dbo.users (status, modified_by, modified_at, first_name, last_name, email, phone_no, password) " +
                    $"values (1, 1, @value, '{fname}', '{lname}', '{email}', {phone}, '{password}');";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", DateTime.Now);
                command.ExecuteNonQuery();
            }

            return View("Login");
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult Admin_start(string apartmentNumber, string floorNumber, string block, string advanceAmount,
            string rentalCost, string bedrooms, string floorSpace, string status, string noticePeriod)
        {
            using (var connection = DbUtils.GetConnection())
            {
                connection.Open();

                string query = $"insert into dbo.Apartments(status, modified_by, modified_at, block, apartment_no, floor_num, bhk, advance_amt, rent_cost, floor_space, notice_period, is_rented)" +
                    $"values(1, 1, @value, '{block}', {apartmentNumber}, {floorNumber}, {bedrooms}, {advanceAmount},{rentalCost},{floorSpace},{noticePeriod}, 0);";

                Debug.WriteLine(query);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", DateTime.Now);
                command.ExecuteNonQuery();
            }

            return View();
        }
	}
}
