using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationCreate
    {
        public int ConversationId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public IList<Message> User1Message { get; set; }
        public IList<Message> User2Message { get; set; }
        public int FriendId { get; set; }
    }
}
