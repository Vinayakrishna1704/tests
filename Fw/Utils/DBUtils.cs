
using System.Data.SqlClient;

namespace Fw.Utils
{

	public static class DbUtils
	{
		private static readonly string connectionString = "Data Source=DESKTOP-9ICU8OK\\SQLEXPRESS;Initial Catalog=Apartment;Integrated Security=True";

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}

	}

}