using System.Collections.Generic;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationEdit
    {
        public int ConversationId { get; set; }
        public ICollection<Message> UserMessages { get; set; }
        
    }
}
