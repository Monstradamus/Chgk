using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace ChgkStorage
{
	[TableName("Players")]
	public class Player
	{
		[PrimaryKey, Identity]
		public int ID;

		[Nullable]
		public int? RatingID;
		public String Surname;
		public String Name;
		public String Patronymic;
		public int? TeamID;

		public Player(int ID, int? RatingID, String Surname, String Name, String Patronymic, int? TeamID)
		{
			this.ID = ID;
			this.Surname = Surname;
			this.Name = Name;
			this.Patronymic = Patronymic;
			this.RatingID = RatingID;
			this.TeamID = TeamID;
		}
	}
}

