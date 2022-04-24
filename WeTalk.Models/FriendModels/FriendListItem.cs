using System;
using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.FriendModels
{
    public class FriendListItem
    {
        [Display(Name = "Friend 1")]
        public string UserName1 { get; set; }
        [Display(Name = "Friend 2")]
        public string UserName2 { get; set; }
        [Display(Name = "Friends Since")]
        public DateTimeOffset FriendsSince { get; set; }
        public int FriendId { get; set; }
    }
}
