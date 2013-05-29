using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace ChgkStorage
{
	[TableName("Teams")]
	public class Team
	{
		[PrimaryKey, Identity]
		public int ID;

		[NotNull]
		public String Name;
		public int? RatingID;

		[Association(ThisKey="ID", OtherKey="TeamID")]
		public List<Player> PlayersList;
	}
}

