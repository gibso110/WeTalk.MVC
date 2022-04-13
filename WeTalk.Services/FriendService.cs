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



        public bool CreateFriend(FriendCreate model)
        {
            

            var entity =
                new Friend
                {   
                    //User1Id = ApplicationUser,
                    User2Id = model.User2Id,
                    FriendsSince = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext()){
                ctx.Friends.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
