using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

public static class ServicesUtils
    {
        public static bool IsPasswordCheck(string password)
        {
        //string pattern = "[a - zA - z0 - 9\\-!@#%^&*()+={}|\\/<>?\\[\\]]{10,}";
        string pattern = "(?=.*[a-z])(?=.*[0-9])(?=.*[A-Z])(?=.*[!@#$%^&*()-+=_{}\\[\\];'\":|\\<>\\?\\/])[A-Za-z0-9\\!~`@#$%^&*()_\\-+={\\[\\]}|\\:;'\",.<>?\\/]{10,}";
            return Regex.IsMatch(password, pattern);
        }
        public static bool IsEmailCheck(string email)
    {
        string mailpat = "[a-zA-Z0-9_\\-\\.]+[@][a-z]+[\\.][a-z]{2,3}";
        return Regex.IsMatch(email, mailpat);
    }
    }
