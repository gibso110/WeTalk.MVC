namespace WeTalk.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixedIdentityModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationUser", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUser", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ApplicationUser", "ApplicationUser_Id");
        }
    }
}
