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
        
        [HttpGet]
        public ActionResult Home()
        {
            DataTable tab = new DataTable();
            using (var connection=DbUtils.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM apartments"; 
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(tab);

            }
            List<DataRow> rows = tab.AsEnumerable().ToList<DataRow>();
            return View(rows);
        }
        [HttpPost]
        public ActionResult Home(int? bhk ,int? cost,int? floorspace,int? vacancy)
        {
            DataTable tab = new DataTable();
            if (vacancy.HasValue)
            {
                using(var connection = DbUtils.GetConnection())
                {
                    
                    
                     if (vacancy.Value==1)
                    {
                        string query = "SELECT * FROM apartments WHERE is_rented=1";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);

                    }
                    else
                    {
                        string query = "SELECT * FROM apartments WHERE is_rented=0";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                }
            }
            if (bhk.HasValue)
            {
                
                using(var connection = DbUtils.GetConnection())
                {
                    connection.Open();
                    if (bhk.ToString() == "")
                    {
                        string query = "SELECT * FROM apartments";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);

                    }
                    else {
                        string query = "SELECT * FROM apartments WHERE bhk=" + bhk.ToString();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
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
                    if (cost.ToString() == "")
                    {
                        string query2 = "SELECT * FROM apartments";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if (cost.ToString() == "1")
                    {
                        string query2 = "SELECT * FROM apartments WHERE rent_cost BETWEEN 0 AND 5001";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);


                    }

                    else if (cost.ToString()=="11")
                    {
                         string query2 = "SELECT * FROM apartments WHERE rent_cost BETWEEN 8002 AND 10001";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(cost.ToString()=="10")
                    {
                        string query2 = "SELECT * FROM apartments WHERE rent_cost BETWEEN 5002 AND 8001";
                        SqlCommand command = new SqlCommand(query2, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(cost.ToString()=="2")
                    {
                        

                        string query2 = "SELECT * FROM apartments WHERE rent_cost NOT BETWEEN 0 AND 10001";
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
                    if (floorspace.ToString() == "")
                    {
                        string query3 = "SELECT * FROM apartments";
                        SqlCommand command = new SqlCommand(query3, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);

                    }
                    else if (floorspace.ToString() == "1")
                    {
                        string query3 = "SELECT * FROM apartments WHERE floor_space BETWEEN 0 AND 200";
                        SqlCommand command = new SqlCommand(query3, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(floorspace.ToString()=="11")
                    {
                        string query = "SELECT * FROM apartments WHERE floor_space BETWEEN 300  AND 400";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(floorspace.ToString()=="10")
                    {
                        string query = "SELECT * FROM apartments WHERE floor_space BETWEEN 201 AND 299";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(tab);
                    }
                    else if(floorspace.ToString()=="2")
                    {
                        

                        string query = "SELECT * FROM apartments WHERE floor_space NOT BETWEEN 0 AND 400";
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

            if (ServicesUtils.IsPasswordCheck(password) != true)
            {
                ViewBag.ErrorMessage = "Password Requirement Not Met";
                return View();
            }
            else if (ServicesUtils.IsEmailCheck(email) != true)
            {
                ViewBag.ErrorMessage = "Email Pattern Not Right";
                return View();
            }

            else
            {
                try
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

                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Email already used";
                    return View();
                }
            }
        }

        
        
    }
}
