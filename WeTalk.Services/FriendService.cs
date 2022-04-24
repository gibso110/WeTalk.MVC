using System;
using System.Collections.Generic;
using System.Linq;
using WeTalk.Data;
using WeTalk.Models.ConversationModels;
using WeTalk.Models.FriendModels;


namespace WeTalk.Services
{
    public class FriendService
    { 
        public ConversationService CreateConversationService()
        {
            return new ConversationService(_userId);
        }

        private readonly string _userId;

        

        public FriendService(string userId)
        {
            _userId = userId;
        }
        //view sent friend requests



        //View all Friends
        public IEnumerable<FriendListItem> GetAllFriends()
        {
            using (var ctx = new ApplicationDbContext())
            {


                var query = ctx.Friends
                    .Where(n => n.User1Id == _userId || n.User2Id == _userId)
                    .Select(n => new FriendListItem()
                    {
                        UserName1 = n.ApplicationUser.UserName,
                        UserName2 = n.ApplicationUser2.UserName,
                        FriendsSince = n.FriendsSince,
                        FriendId = n.FriendshipId
                    });
                return query.ToArray();
            }
        }

        //public IEnumerable<FriendDetail> GetFriendByUsername()

        public FriendDetail GetFriendByUsername(string username)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Friends
                    .Find(username);

                if(query != null)
                return new FriendDetail
                {
                    FullName = query.ApplicationUser2.FullName,
                    UserName = query.ApplicationUser2.UserName,
                    FriendsSince = query.FriendsSince
                };


            }
            return null;
        }

        //Create A New Friend

        public bool FriendCreate(FriendCreate model)
        {
            var entity =
                new Friend()
                {
                    FriendshipId = model.FriendhipId,
                    User1Id = _userId,
                    User2Id = model.User2Id,
                    FriendsSince = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                
                ctx.Friends.Add(entity);
                return ctx.SaveChanges()  == 1;
            }
        }


        //Delete a friend
        public bool FriendDelete(int friendId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Friends
                        .Single(e => e.FriendshipId == friendId);
                ctx.Friends.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

        //get friend by id

        public FriendDetail GetFriendById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Friends
                    .Single(e => e.FriendshipId == id);

                return new FriendDetail()
                {
                    UserName = entity.ApplicationUser2.UserName,
                    FriendsSince = entity.FriendsSince,
                    FullName = entity.ApplicationUser2.FullName

                };
            }
        }
    }
}
