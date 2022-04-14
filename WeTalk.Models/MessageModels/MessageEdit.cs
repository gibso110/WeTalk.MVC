using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.MessageModels
{
    public class MessageEdit
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTimeOffset EditedTimestamp { get; set; }
    }
}
