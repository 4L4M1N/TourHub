namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTourTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Place = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre_Id = c.Byte(),
                        Traveller_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Traveller_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Traveller_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "Traveller_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tours", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Tours", new[] { "Traveller_Id" });
            DropIndex("dbo.Tours", new[] { "Genre_Id" });
            DropTable("dbo.Tours");
            DropTable("dbo.Genres");
        }
    }
}
