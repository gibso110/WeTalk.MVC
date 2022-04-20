using System.Collections.Generic;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationEdit
    {
        public int ConversationId { get; set; }
        public IList<Message> User1Messages { get; set; }
        public IList<Message> User2Messages { get; set; }
    }
}
