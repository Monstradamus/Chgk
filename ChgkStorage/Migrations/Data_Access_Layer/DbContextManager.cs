using System;


namespace ChgkStorage
{
	public abstract class DbContextManager
	{
		public abstract DBContext CreateContext();

		public void Exec(Action<DBContext> cb)
		{
			Exec<object>(db => { cb(db); return null; });
		}

		public T Exec<T>(Func<DBContext, T> cb)
		{
			using (var ctx = CreateContext())
			{
				return cb(ctx);
			}
		}
	}
}

