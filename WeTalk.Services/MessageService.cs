using System;
using System.Collections;
using System.Linq;
using WeTalk.Data;
using WeTalk.Models.MessageModels;

namespace WeTalk.Services
{
    public class MessageService
    {
        private readonly string _userId;

        public MessageService(string userId)
        {
            _userId = userId;
        }

        //Create a message

        public bool CreateAMessage(MessageCreate model,string username)
        {
            

            using (var ctx = new ApplicationDbContext())
            {
                var existingConversation =
                    ctx.Conversations
                    .Single(n => n.User1Id == _userId && n.ApplicationUser2.UserName == username || n.User2Id == _userId & n.ApplicationUser.UserName == username);
                
                var entity =
                   new Message()
                   {
                       MessageId = model.MessageId,
                       MessageContent = model.MessageContent,
                       TimeStamp = DateTimeOffset.Now,
                       ConversationId = existingConversation.ConversationId
                   };
                
                ctx.Messages.Add(entity);
                var query =
                    ctx.Conversations
                    .Find(model.ConversationId);
                if(query.User1Id == _userId)
                {
                    query.User1Message.Add(entity);
                }
                else if(query.User2Id == _userId){
                    query.User2Message.Add(entity);
                }
                return ctx.SaveChanges() == 1;
            }



        }

        //Edit a message
        public bool EditAMessage(MessageEdit model)
        {


            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                ctx
                    .Messages
                    .Single(n => n.MessageId == model.MessageId);

                entity.MessageId = model.MessageId;
                entity.MessageContent = model.MessageContent;
                entity.EditedTimeStamp = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;

            }
        }
        


        //Delete a message

        public bool DeleteAMessage(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.FriendRequests
                    .Single(n => n.RequestId == id);
                ctx.FriendRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
