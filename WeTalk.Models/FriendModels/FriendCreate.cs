using System;

namespace WeTalk.Models.FriendModels
{
    public class FriendCreate
    {
        public int FriendhipId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
