using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;
using WeTalk.Models.ConversationModels;

namespace WeTalk.Services
{
    public class ConversationService
    {
        private readonly string _userId;

        public ConversationService(string userId)
        {
            _userId = userId;
        }

        //Create a conversation

        public bool CreateConversation(ConversationCreate model)
        {
            var entity = new Conversation
            {
                ConversationId = model.ConversationId,
                User1Id = model.User1Id,
                User2Id = model.User2Id,
                FriendId = model.FriendId,
                User1Message = model.User1Message,
                User2Message = model.User2Message,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Conversations.Add(entity);

                return ctx.SaveChanges() == 1;
            }

        }

        //get all conversations

        public IEnumerable<ConversationListItem> GetAllConversations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Conversations
                    .Select(n => new ConversationListItem()
                    {
                        UserName2 = n.ApplicationUser2.UserName,
                        User1Messages = n.User1Message,
                        User2Messages = n.User2Message
                    });
                return query.ToArray();
            }
        }

        //get conversation by id
        public ConversationDetail GetConversationById(int id)
        {
            var entity = new ConversationDetail();

            using(var ctx = new ApplicationDbContext())
            {
                var query =

                ctx.Conversations
                .Single(n => n.ConversationId == id);

                return new ConversationDetail()
                {
                    Username1 = query.ApplicationUser.UserName,
                    Username2 = query.ApplicationUser2.UserName,
                    User1Messages = query.User1Message,
                    User2Messages = query.User2Message
                };
            }
        }
        //update a conversation
        public bool UpdateAConversation(ConversationEdit model)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Conversations
                    .Single(n=> n.ConversationId == model.ConversationId);

                entity.User1Message = model.User1Messages;
                entity.User2Message = model.User2Messages;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete a conversation

        public bool DeleteAConversation(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Conversations.Single(n => n.ConversationId == id);
                   
                ctx.Conversations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
