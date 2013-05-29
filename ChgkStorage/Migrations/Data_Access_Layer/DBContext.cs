using System;
using System.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Data.Linq;

namespace ChgkStorage
{
	public class DBContext : BLToolkit.Data.DbManager
	{
		public Table<Team> Teams
		{
			get { return GetTable<Team>(false); }
		}

		public Table<Player> Players
		{
			get { return GetTable<Player>(); }
		}

		public DBContext(DataProviderBase provider, IDbConnection conn) : base(provider, conn) { }
	}
}

