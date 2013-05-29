using System;
using System.Collections.Generic;
using System.Linq;

namespace ChgkStorage
{
	public class ChgkStorage
	{
		readonly DbContextManager _manager;

		public ChgkStorage(DbContextManager manager)
		{
			_manager = manager;
		}

		public IEnumerable<Team> GetAllTeams()
		{
			return _manager.Exec(db => db.Teams.Select(t => new Team 
			                                           { 
				ID = t.ID, 
				Name = t.Name, 
				RatingID = t.RatingID, 
				PlayersList = t.PlayersList.ToList<Player>()
			}));
		}
	}
}

