using System;
using BLToolkit.Data.DataProvider;

namespace ChgkStorage
{
	public class MySqlContextManager : DbContextManager
	{
		readonly string _connString;

		public MySqlContextManager(string connString)
		{
			_connString = connString;
		}

		public override DBContext CreateContext()
		{
			return new DBContext(new MySqlDataProvider(), new System.Data.SqlClient.SqlConnection(_connString));
		}
	}
}

