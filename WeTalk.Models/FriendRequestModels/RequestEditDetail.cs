using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendRequestModels
{
    public class RequestEditDetail
    {
        [Display(Name ="Accept this request?")]
        public bool IsAccepted { get; set; }
        [Display(Name = "Block this request?")]
        public bool IsBlocked { get; set; }

        public int RequestId { get; set; }

        public string User2Id { get; set; }

    }
}
