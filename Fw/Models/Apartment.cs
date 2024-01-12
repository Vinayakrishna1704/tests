using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fw.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        //public string UserName { get; set; }
        public string Block { get; set; } // Be cautious about storing plain passwords.
        public int Floor_num { get; set; }
        public int Apartment_no { get; set; }
        public int Bhk { get; set; }
        public int Advance_amt { get; set; }
        public int Rent_cost { get; set; }
        public int Isrented { get; set; }
        public string Floor_space { get; set; }
        public string Notice_period { get; set; }
        public int User_id { get; set; }
        public bool Status { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}