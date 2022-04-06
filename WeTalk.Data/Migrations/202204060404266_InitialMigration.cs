namespace WeTalk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conversation", "User1Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Conversation", "User2Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Conversation", "FriendId", c => c.Int(nullable: false));
            AddColumn("dbo.FriendRequest", "User1Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FriendRequest", "User2Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FriendRequest", "IsAccepted", c => c.Boolean(nullable: false));
            AddColumn("dbo.FriendRequest", "IsBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Friend", "User1Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Friend", "User2Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Friend", "FriendsSince", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Conversation", "User1Id");
            CreateIndex("dbo.Conversation", "User2Id");
            CreateIndex("dbo.Conversation", "FriendId");
            CreateIndex("dbo.Friend", "User1Id");
            CreateIndex("dbo.Friend", "User2Id");
            CreateIndex("dbo.FriendRequest", "User1Id");
            CreateIndex("dbo.FriendRequest", "User2Id");
            AddForeignKey("dbo.Conversation", "User1Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Conversation", "User2Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Friend", "User1Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Friend", "User2Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Conversation", "FriendId", "dbo.Friend", "FriendshipId", cascadeDelete: true);
            AddForeignKey("dbo.FriendRequest", "User1Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
            AddForeignKey("dbo.FriendRequest", "User2Id", "dbo.ApplicationUser", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequest", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FriendRequest", "User1Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "FriendId", "dbo.Friend");
            DropForeignKey("dbo.Friend", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "User1Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "User1Id", "dbo.ApplicationUser");
            DropIndex("dbo.FriendRequest", new[] { "User2Id" });
            DropIndex("dbo.FriendRequest", new[] { "User1Id" });
            DropIndex("dbo.Friend", new[] { "User2Id" });
            DropIndex("dbo.Friend", new[] { "User1Id" });
            DropIndex("dbo.Conversation", new[] { "FriendId" });
            DropIndex("dbo.Conversation", new[] { "User2Id" });
            DropIndex("dbo.Conversation", new[] { "User1Id" });
            DropColumn("dbo.Friend", "FriendsSince");
            DropColumn("dbo.Friend", "User2Id");
            DropColumn("dbo.Friend", "User1Id");
            DropColumn("dbo.FriendRequest", "IsBlocked");
            DropColumn("dbo.FriendRequest", "IsAccepted");
            DropColumn("dbo.FriendRequest", "User2Id");
            DropColumn("dbo.FriendRequest", "User1Id");
            DropColumn("dbo.Conversation", "FriendId");
            DropColumn("dbo.Conversation", "User2Id");
            DropColumn("dbo.Conversation", "User1Id");
        }
    }
}
