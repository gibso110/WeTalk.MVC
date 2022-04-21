using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;

namespace WeTalk.Models.FriendRequestModels
{
    public class FriendRequestDetail
    {
        [Display(Name ="Request Id")]
        public int RequestId { get; set; }
        [Display(Name = "User1 Id")]
        public string User1Id { get; set; }
        [Display(Name = "User2 Id")]
        public string User2Id { get; set; }
        [Display(Name = "Is accepted?")]
        public bool IsAccepted { get; set; }
        [Display(Name = "Is Blocked")]
        public bool IsBlocked { get; set; }
        [Display(Name ="User 1 Messages:")]
        public IList<Message> User1Messages { get; set; }
        public IList<Message> User2Messages { get; set; }
    }

}
