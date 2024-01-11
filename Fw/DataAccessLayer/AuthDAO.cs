using Fw.Models;
using Fw.Models.mapper;
using Fw.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fw.DataAccessLayer
{
	public class AuthDAO
	{
		public User GetUserByUsername(string username)
		{
			using (var connection = DbUtils.GetConnection())
			{
				SqlCommand command = new SqlCommand("select * from users where email='"+ username + "'", connection);

				User user=null;

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						 user= UserMapper.MapToUser(reader);
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					
					throw ex;
				}

				return user;
			}
			
		}
			
		
	}
}