using System.Collections.Generic;
using System.Linq;
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
                User1Id = _userId,
                User2Id = model.User2Id,
                FriendId = model.FriendId,
                UserMessages = model.UserMessages
                
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
                    .Where(x => x.User1Id == _userId || x.User2Id == _userId)
                    .Select(n => new ConversationListItem()
                    {
                       
                        UserName2 = n.ApplicationUser2.UserName,
                        UserMessages = n.UserMessages,
                        
                    });
                return query.ToArray();
            }
        }

        //get conversation by id
        public ConversationDetail GetConversationById(int id)
        {
            var entity = new ConversationDetail();

            using (var ctx = new ApplicationDbContext())
            {
                var query =

                ctx.Conversations
                .Single(n => n.ConversationId == id);
                if(query.User1Id == _userId) { 
                return new ConversationDetail()
                {
                    Username1 = query.ApplicationUser.UserName,
                    Username2 = query.ApplicationUser2.UserName,
                    UserMessages = query.UserMessages,
                    
                };
                }
                else
                {
                    return new ConversationDetail()
                    {
                        Username1 = query.ApplicationUser2.UserName,
                        Username2 = query.ApplicationUser.UserName,
                        UserMessages = query.UserMessages,
                        
                    };
                }
            }
        }
        //update a conversation
        public bool UpdateAConversation(ConversationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Conversations
                    .Single(n => n.ConversationId == model.ConversationId);

                entity.UserMessages = model.UserMessages;
                entity.UserMessages = model.UserMessages;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete a conversation

        public bool DeleteAConversation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Conversations.Single(n => n.ConversationId == id);

                ctx.Conversations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
