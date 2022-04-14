using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;
using WeTalk.Models.FriendRequestModels;


namespace WeTalk.Services
{
    
    public class FriendRequestService
    {
        private readonly string _userId;

        public FriendRequestService(string userId)
        {
            userId = _userId;
        }

        //Create a new friend request

        
        public bool CreateFriendRequest (CreateFriendRequest model)
        {
            

            var entity = new FriendRequest()
            {
                RequestId = model.RequestId,
                User1Id = model.User1Id,
                User2Id = model.User2Id,

            };

           

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.FriendRequests.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            
        }


        //Friend request edit

        public bool EditFriendRequest (FriendRequestEdit model)
        {
            var entity = new FriendRequestEdit()
            {
                RequestId = model.RequestId,
                isAccepted = model.isAccepted,
                isBlocked = model.isBlocked
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.FriendRequests
                    .Single(n => n.RequestId == model.RequestId);

                    entity.isAccepted = model.isBlocked;
                    entity.isBlocked = model.isAccepted;

                return ctx.SaveChanges() == 1;
            }
        }


        //Friend Request delete

        public bool deleteFriendRequest(int requestId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =

                ctx.FriendRequests
                    .Single(n=> requestId == n.RequestId);
                
                ctx.FriendRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
