namespace WeTalk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "TimeStamp", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Message", "EditedTimeStamp", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Message", "Conversation_ConversationId", c => c.Int());
            AddColumn("dbo.Message", "Conversation_ConversationId1", c => c.Int());
            CreateIndex("dbo.Message", "Conversation_ConversationId");
            CreateIndex("dbo.Message", "Conversation_ConversationId1");
            AddForeignKey("dbo.Message", "Conversation_ConversationId", "dbo.Conversation", "ConversationId");
            AddForeignKey("dbo.Message", "Conversation_ConversationId1", "dbo.Conversation", "ConversationId");
            DropColumn("dbo.Message", "MessageDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "MessageDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.Message", "Conversation_ConversationId1", "dbo.Conversation");
            DropForeignKey("dbo.Message", "Conversation_ConversationId", "dbo.Conversation");
            DropIndex("dbo.Message", new[] { "Conversation_ConversationId1" });
            DropIndex("dbo.Message", new[] { "Conversation_ConversationId" });
            DropColumn("dbo.Message", "Conversation_ConversationId1");
            DropColumn("dbo.Message", "Conversation_ConversationId");
            DropColumn("dbo.Message", "EditedTimeStamp");
            DropColumn("dbo.Message", "TimeStamp");
        }
    }
}
