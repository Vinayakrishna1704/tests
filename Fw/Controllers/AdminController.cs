using Fw.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fw.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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

                string query = $"insert into dbo.apartments(status, modified_by, modified_at, block, apartment_no, floor_num, bhk, advance_amt, rent_cost, floor_space, notice_period, isrented,user_id)" +
                    $"values(1, 1, @value, '{block}', {apartmentNumber}, {floorNumber}, {bedrooms}, {advanceAmount},{rentalCost},{floorSpace},{noticePeriod}, 0,1);";

                Debug.WriteLine(query);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", DateTime.Now);
                command.ExecuteNonQuery();
            }

            return View();
        }
    }
}