using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendRequestModels
{
    public class FriendRequestEdit
    {
        public int RequestId { get; set; }
        public bool isAccepted { get; set; }
        public bool isBlocked { get; set; }

    }
}
