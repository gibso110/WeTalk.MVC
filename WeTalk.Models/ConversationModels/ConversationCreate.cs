using System.Collections.Generic;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationCreate
    {
        public int ConversationId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public IList<Message> User1Message = new List<Message>();
        public IList<Message> User2Message = new List<Message>();
        public int FriendId { get; set; }
    }
}
