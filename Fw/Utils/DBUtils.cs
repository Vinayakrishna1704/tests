
using System.Data.SqlClient;

namespace Fw.Utils
{

	public static class DbUtils
	{
		private static readonly string connectionString = "Data Source=.;Initial Catalog=Apartment;Integrated Security=True";

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}

	}

}