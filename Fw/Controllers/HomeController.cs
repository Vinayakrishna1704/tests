using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
	}
}
