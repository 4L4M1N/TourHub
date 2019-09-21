namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seatadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "TotalSeat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "TotalSeat");
        }
    }
}
