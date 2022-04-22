using System.Collections.Generic;
using System.Linq;
using WeTalk.Data;
using WeTalk.Models.FriendRequestModels;
using System;
using WeTalk.Models.FriendModels;
using WeTalk.Models.ConversationModels;

namespace WeTalk.Services
{

    public class FriendRequestService
    {
        public FriendService CreateFriendService()
        {
            return new FriendService(_userId);
        }

        public ConversationService CreateConversationService()
        {
            return new ConversationService(_userId);
        }

        private readonly string _userId;

        public FriendRequestService(string userId)
        {
            _userId = userId;
        }

        //Create a new friend request


        public bool CreateFriendRequest(FriendRequestCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                   .Users
                   .Single(n => n.UserName == model.Username);
                var entity =
                    new FriendRequest
                    {
                        User1Id = _userId,
                        User2Id = query.Id,

                    };
                ctx.FriendRequests.Add(entity);

                return ctx.SaveChanges() == 1;
            }

        }

    

        //Friend request edit

        public bool EditFriendRequest(RequestEditDetail model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FriendRequests
                    .Single(n => n.RequestId == model.RequestId);
                entity.RequestId = model.RequestId;
                entity.IsBlocked = model.IsBlocked;
                entity.IsAccepted = model.IsAccepted;

                if (model.IsAccepted == true)
                {
                   


                    var newFriend = new FriendCreate()
                    {
                        User1Id = _userId,
                        User2Id = model.User2Id,
                     };


                    CreateFriendService().FriendCreate(newFriend);

                    var query =
                        ctx.Friends
                        .Single(n => n.User1Id == _userId && n.User2Id == model.User2Id);

                    var newConversation = new ConversationCreate()
                    {
                        User1Id = _userId,
                        User2Id = query.User2Id,
                        FriendId = query.FriendshipId
                    };

                    

                    return CreateConversationService().CreateConversation(newConversation);
                }

                return ctx.SaveChanges() == 1;
            }
        }


        //Friend Request delete

        public bool deleteFriendRequest(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                ctx
                .FriendRequests
                 .Find(id);

                if(entity != null)
                {
                    ctx.FriendRequests.Remove(entity);
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;


            }
            
        }

        //Get all friend requests

        public IEnumerable<FriendRequestListItem> GetAllFriendRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.FriendRequests
                    .Where(n => n.User2Id == _userId)
                    .Select(n => new FriendRequestListItem()
                    {

                        UserName2 = n.ApplicationUser.UserName,
                        User2FullName = n.ApplicationUser.FullName
                    });
                return query.ToArray();
            }
        }

        //Get Friend Request by Id

        public FriendRequestListItem GetFriendRequestById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FriendRequests
                    .Single(n => n.RequestId == id);
                if(query != null) { 
                return new FriendRequestListItem
                {
                    UserName2 = query.ApplicationUser.UserName,
                    User2FullName = query.ApplicationUser.FullName
                };
                }
                return null;
            }
        }

        //Get Friend Request Edit View Model

        public RequestEditDetail RequestEditView(int id)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FriendRequests
                    .Single(n => n.RequestId == id);

                if(entity != null)
                {
                    return new RequestEditDetail
                    {
                        RequestId = entity.RequestId,
                        User2Id = entity.User1Id,
                        IsAccepted = entity.IsAccepted,
                        IsBlocked = entity.IsBlocked,
                    };
                }
                return null;
            }

        }

    }
}
