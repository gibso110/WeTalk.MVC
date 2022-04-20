using System;
using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.FriendModels
{
    public class FriendListItem
    {
        [Display(Name = "You")]
        public string UserName1 { get; set; }
        [Display(Name = "Friend's Username")]
        public string UserName2 { get; set; }
        [Display(Name = "Friends Since")]
        public DateTimeOffset FriendsSince { get; set; }
    }
}
