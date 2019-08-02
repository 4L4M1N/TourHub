namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Hiking')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Hill tracking')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Wildlife')");
            //Cruise 
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Cruise')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5)");
        }
    }
}
