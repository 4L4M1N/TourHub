namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyTour : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tours", name: "Genre_Id", newName: "GenreID");
            RenameColumn(table: "dbo.Tours", name: "Traveller_Id", newName: "TravellerID");
            RenameIndex(table: "dbo.Tours", name: "IX_Traveller_Id", newName: "IX_TravellerID");
            RenameIndex(table: "dbo.Tours", name: "IX_Genre_Id", newName: "IX_GenreID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tours", name: "IX_GenreID", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Tours", name: "IX_TravellerID", newName: "IX_Traveller_Id");
            RenameColumn(table: "dbo.Tours", name: "TravellerID", newName: "Traveller_Id");
            RenameColumn(table: "dbo.Tours", name: "GenreID", newName: "Genre_Id");
        }
    }
}
