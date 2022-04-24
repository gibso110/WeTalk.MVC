namespace WeTalk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversation",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                        User1Id = c.String(nullable: false, maxLength: 128),
                        User2Id = c.String(nullable: false, maxLength: 128),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConversationId)
                .ForeignKey("dbo.ApplicationUser", t => t.User1Id, cascadeDelete: false)
                .ForeignKey("dbo.ApplicationUser", t => t.User2Id, cascadeDelete: false)
                .ForeignKey("dbo.Friend", t => t.FriendId, cascadeDelete: false)
                .Index(t => t.User1Id)
                .Index(t => t.User2Id)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        FriendshipId = c.Int(nullable: false, identity: true),
                        User1Id = c.String(nullable: false, maxLength: 128),
                        User2Id = c.String(nullable: false, maxLength: 128),
                        FriendsSince = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.FriendshipId)
                .ForeignKey("dbo.ApplicationUser", t => t.User1Id, cascadeDelete: false)
                .ForeignKey("dbo.ApplicationUser", t => t.User2Id, cascadeDelete: false)
                .Index(t => t.User1Id)
                .Index(t => t.User2Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        MessageContent = c.String(nullable: false),
                        TimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                        EditedTimeStamp = c.DateTimeOffset(precision: 7),
                        ConversationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Conversation", t => t.ConversationId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.FriendRequest",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        User1Id = c.String(nullable: false, maxLength: 128),
                        User2Id = c.String(nullable: false, maxLength: 128),
                        IsAccepted = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.ApplicationUser", t => t.User1Id, cascadeDelete: false)
                .ForeignKey("dbo.ApplicationUser", t => t.User2Id, cascadeDelete: false)
                .Index(t => t.User1Id)
                .Index(t => t.User2Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FriendRequest", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FriendRequest", "User1Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Message", "ConversationId", "dbo.Conversation");
            DropForeignKey("dbo.Message", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "FriendId", "dbo.Friend");
            DropForeignKey("dbo.Friend", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "User1Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "User2Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Conversation", "User1Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.FriendRequest", new[] { "User2Id" });
            DropIndex("dbo.FriendRequest", new[] { "User1Id" });
            DropIndex("dbo.Message", new[] { "ConversationId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Friend", new[] { "User2Id" });
            DropIndex("dbo.Friend", new[] { "User1Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Conversation", new[] { "FriendId" });
            DropIndex("dbo.Conversation", new[] { "User2Id" });
            DropIndex("dbo.Conversation", new[] { "User1Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.FriendRequest");
            DropTable("dbo.Message");
            DropTable("dbo.Friend");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Conversation");
        }
    }
}
