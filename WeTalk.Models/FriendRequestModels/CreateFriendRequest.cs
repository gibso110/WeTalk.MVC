using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendRequestModels
{
    public class CreateFriendRequest
    {
        public int RequestId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public int MyProperty { get; set; }
    }
}
