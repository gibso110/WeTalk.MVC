using System;
using System.Collections;
using System.Collections.Generic;
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

        public bool CreateAMessage(MessageCreate model)
        {
            

            using (var ctx = new ApplicationDbContext())
            {
                var existingConversation =
                    ctx.Conversations
                    .Single(n => n.User1Id == _userId && n.ApplicationUser2.UserName == model.Username || n.User2Id == _userId & n.ApplicationUser.UserName == model.Username);
                
                var entity =
                   new Message()
                   {
                       UserId = _userId,
                       MessageId = model.MessageId,
                       MessageContent = model.MessageContent,
                       TimeStamp = DateTimeOffset.Now,
                       ConversationId = existingConversation.ConversationId
                   };
                
                ctx.Messages.Add(entity);
                var savechange =
                    ctx.SaveChanges();

                existingConversation =
                     ctx.Conversations
                     .Single(n => n.User1Id == _userId && n.ApplicationUser2.UserName == model.Username || n.User2Id == _userId & n.ApplicationUser.UserName == model.Username);


              
            }
            return true;



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

        //Get message by id
        public MessageDisplay GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Messages
                    .Single(n => n.MessageId == id);
                if (query != null)
                {
                    return new MessageDisplay
                    {
                        UserName = query.ApplicationUser.UserName,
                        MessageContent = query.MessageContent,
                        MessageId = query.MessageId
                    };
                }
                return null;
            }
        }
    }
}
