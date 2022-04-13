namespace WeTalk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendsModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUser", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ApplicationUser", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationUser", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
