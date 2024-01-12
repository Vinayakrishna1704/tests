using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fw.Models.mapper
{
    public static class ApartmentMapper
    {
        public static Apartment MapToApartment(SqlDataReader reader)
        {
            Apartment apartment = new Apartment();
            apartment.Id = reader.GetInt32(reader.GetOrdinal("id"));
            //user.UserName = reader["user_name"] as string;
            apartment.Block = reader["block"] as string;
            apartment.Floor_num = reader.GetInt32(reader.GetOrdinal("floor_num")); ;
            apartment.Apartment_no = reader.GetInt32(reader.GetOrdinal("apartment_no"));
            apartment.Bhk = reader.GetInt32(reader.GetOrdinal("bhk"));
            apartment.Advance_amt = reader.GetInt32(reader.GetOrdinal("advance_amt"));
            apartment.Rent_cost = reader.GetInt32(reader.GetOrdinal("rent_cost"));
            apartment.Isrented = reader.GetInt32(reader.GetOrdinal("isrented"));
            apartment.Floor_space = reader["floor_space"] as string;
            apartment.Notice_period = reader["notice_period"] as string;
            apartment.User_id = reader.GetInt32(reader.GetOrdinal("user_id"));
            apartment.Status = reader.GetByte(reader.GetOrdinal("status")) != 0;
            apartment.ModifiedBy = reader.GetInt32(reader.GetOrdinal("modified_by"));
            apartment.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("modified_at"));
            return apartment;
        }
    }
}