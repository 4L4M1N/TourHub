namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "IsCanceled");
        }
    }
}
