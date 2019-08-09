namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        TourId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TourId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourId)
                .Index(t => t.TourId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Attendences", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "AttendeeId" });
            DropIndex("dbo.Attendences", new[] { "TourId" });
            DropTable("dbo.Attendences");
        }
    }
}
