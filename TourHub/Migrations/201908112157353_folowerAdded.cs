namespace TourHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class folowerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        FolloweeId = c.Int(nullable: false),
                        Follower_Id = c.String(nullable: false, maxLength: 128),
                        Followee_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Followee_Id)
                .Index(t => t.Follower_Id)
                .Index(t => t.Followee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Followee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Followee_Id" });
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropTable("dbo.Followings");
        }
    }
}
