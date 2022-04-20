using System.Collections.Generic;
using System.Linq;
using WeTalk.Data;
using WeTalk.Models.FriendRequestModels;
using System;
using WeTalk.Models.FriendModels;

namespace WeTalk.Services
{

    public class FriendRequestService
    {
        public FriendService CreateFriendService()
        {
            return new FriendService(_userId);
        }

        private readonly string _userId;

        public FriendRequestService(string userId)
        {
            _userId = userId;
        }

        //Create a new friend request


        public bool CreateFriendRequest(CreateFriendRequest model, string username)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Friends
                    .Find(username);

                var entity = new FriendRequest()
                {
                    RequestId = model.RequestId,
                    User1Id = _userId,
                    User2Id = query.User2Id,

                };

                ctx.FriendRequests.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        //Friend request edit

        public bool EditFriendRequest(FriendRequestEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FriendRequests
                    .Single(n => n.RequestId == model.RequestId);

                entity.IsBlocked = model.IsBlocked;
                entity.IsAccepted = model.IsAccepted;

                if (model.IsAccepted == true)
                {
                   


                    var newFriend = new FriendCreate()
                    {
                        User1Id = _userId,
                        User2Id = model.User2Id,
                     };


                    return CreateFriendService().FriendCreate(newFriend);
                }

                return ctx.SaveChanges() == 1;
            }
        }


        //Friend Request delete

        public bool deleteFriendRequest(int requestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                ctx.FriendRequests
                    .Single(n => requestId == n.RequestId);

                ctx.FriendRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
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

                        UserName2 = n.ApplicationUser2.UserName,
                        User2FullName = n.ApplicationUser2.FullName
                    });
                return query.ToArray();
            }
        }

    }
}
