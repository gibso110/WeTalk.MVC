using System;
using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.FriendModels
{
    public class FriendDetail
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Friends Since")]
        public DateTimeOffset FriendsSince { get; set; }
    }
}
