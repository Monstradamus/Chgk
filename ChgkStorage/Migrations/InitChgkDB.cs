using System;
using FluentMigrator;

namespace ChgkStorage
{
	[Migration(201305282231)]
	public class InitChgkDB : Migration
	{
		public override void Up()
		{
			Create.Table("Teams").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("Name").AsString().NotNullable()
					.WithColumn("RatingID").AsInt32().Nullable();

			Create.Table("Tournaments").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("Name").AsString().NotNullable()
					.WithColumn("Synchronous").AsBoolean()
					.WithColumn("Date").AsDateTime()
					.WithColumn("City").AsString()
					.WithColumn("Tours").AsInt32()
					.WithColumn("Questions").AsInt32()
					.WithColumn("Comment").AsString()
					.WithColumn("Price").AsDecimal();

			Create.Table("Players").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("RatingID").AsInt32().Nullable()
					.WithColumn("Surname").AsString()
					.WithColumn("Name").AsString()
					.WithColumn("Patronymic").AsString()
					.WithColumn("TeamID").AsInt32();

			Create.ForeignKey().FromTable("Players").ForeignColumn("TeamID").ToTable("Teams").PrimaryColumn("ID");

			Create.Table("Players_Tournaments").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("PlayerID").AsInt32()
					.WithColumn("TournamentID").AsInt32();

			Create.ForeignKey().FromTable("Players_Tournaments").ForeignColumn("PlayerID").ToTable("Players").PrimaryColumn("ID");
			Create.ForeignKey().FromTable("Players_Tournaments").ForeignColumn("TournamentID").ToTable("Tournaments").PrimaryColumn("ID");

			Create.Table("Payments").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("PlayerID").AsInt32().NotNullable()
					.WithColumn("Amount").AsDecimal().NotNullable();
			Create.ForeignKey().FromTable("Payments").ForeignColumn("PlayerID").ToTable("Players").PrimaryColumn("ID");

			Create.Table("TounnamentPayments").WithColumn("ID").AsInt32().PrimaryKey().Identity()
					.WithColumn("TournamentID").AsInt32().NotNullable()
					.WithColumn("Amount").AsDecimal().NotNullable();
			Create.ForeignKey().FromTable("TounnamentPayments").ForeignColumn("TournamentID").ToTable("Tournaments").PrimaryColumn("ID");
		}

		public override void Down()
		{
			Delete.ForeignKey().FromTable("TounnamentPayments").ForeignColumn("TournamentID").ToTable("Tournaments").PrimaryColumn("ID");
			Delete.Table("TounnamentPayments");

			Delete.ForeignKey().FromTable("Payments").ForeignColumn("PlayerID").ToTable("Players").PrimaryColumn("ID");
			Delete.Table("Payments");

			Delete.ForeignKey().FromTable("Players_Tournaments").ForeignColumn("PlayerID").ToTable("Players").PrimaryColumn("ID");
			Delete.ForeignKey().FromTable("Players_Tournaments").ForeignColumn("PlayerID").ToTable("Players").PrimaryColumn("ID");

			Delete.Table("Players_Tournaments");
			Delete.ForeignKey().FromTable("Players").ForeignColumn("TeamID").ToTable("Teams").PrimaryColumn("ID");

			Delete.Table("Players");
			Delete.Table("Tournaments");
			Delete.Table("Teams");
		}
	}
}

