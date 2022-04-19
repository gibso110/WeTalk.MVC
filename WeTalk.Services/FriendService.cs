using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;
using WeTalk.Models.FriendModels;


namespace WeTalk.Services
{
    public class FriendService
    {

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
                    .Select(n => new FriendListItem()
                    {
                        FriendshipId = n.FriendshipId,
                        UserName1 = n.ApplicationUser.UserName,
                        UserName2 = n.ApplicationUser2.UserName,
                        FriendsSince = n.FriendsSince
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
                    .Single(n=> n.ApplicationUser2.UserName == username);

                return new FriendDetail
                {
                    FullName = query.ApplicationUser2.FullName,
                    UserName = query.ApplicationUser2.UserName,
                    FriendsSince = query.FriendsSince
                };
                
                
            }
        }

        //Create A New Friend

        public bool FriendCreate(FriendCreate model)
        {
            var entity =
                new Friend()
                {
                    FriendshipId = model.FriendhipId,
                    User1Id = model.User1Id,
                    User2Id = model.User2Id,
                    FriendsSince = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Friends.Add(entity);
                return ctx.SaveChanges() == 1;
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
                        .Single(e=> e.FriendshipId == friendId);
                ctx.Friends.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
               
        }
    }
}
