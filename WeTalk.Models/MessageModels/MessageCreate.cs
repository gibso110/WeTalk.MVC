using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.MessageModels
{
    public class MessageCreate
    {
        public int MessageId { get; set; }
        public string UserId { get; set; }
        public string MessageContent { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int ConversationId { get; set; }

    }
}
