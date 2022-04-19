using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendRequestModels
{
    public class FriendRequestListItem
    {
        [Display(Name="Friend Request from:")]
        public string UserName2 { get; set; }
        [Display(Name="Full Name:")]
        public string User2FullName { get; set; }

    }
}
