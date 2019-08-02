namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overrideConventionTourGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tours", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Tours", "Traveller_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tours", new[] { "Genre_Id" });
            DropIndex("dbo.Tours", new[] { "Traveller_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tours", "Place", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tours", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tours", "Traveller_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tours", "Genre_Id");
            CreateIndex("dbo.Tours", "Traveller_Id");
            AddForeignKey("dbo.Tours", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tours", "Traveller_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "Traveller_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tours", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Tours", new[] { "Traveller_Id" });
            DropIndex("dbo.Tours", new[] { "Genre_Id" });
            AlterColumn("dbo.Tours", "Traveller_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tours", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Tours", "Place", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Tours", "Traveller_Id");
            CreateIndex("dbo.Tours", "Genre_Id");
            AddForeignKey("dbo.Tours", "Traveller_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tours", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
