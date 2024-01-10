using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fw.Models
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; } // Be cautious about storing plain passwords.
		public string Role { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public bool Status { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}