using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var entity = 
                new Message()
            {
                MessageId = model.MessageId,
                MessageContent = model.MessageContent,
                TimeStamp= DateTimeOffset.Now,
                ConversationId = model.ConversationId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);

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
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.FriendRequests
                    .Single(n=> n.RequestId == id);
                ctx.FriendRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
