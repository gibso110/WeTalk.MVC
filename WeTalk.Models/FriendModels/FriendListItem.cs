using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendModels
{
    public class FriendListItem
    {
        public int FriendshipId { get; set; }
        public string UserName1 { get; set; }
        public string UserName2{ get; set; }
        [Display(Name="Friends Since:")]
        public DateTimeOffset FriendsSince { get; set; }
    }
}
