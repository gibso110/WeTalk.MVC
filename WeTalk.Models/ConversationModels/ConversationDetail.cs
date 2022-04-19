using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationDetail
    {
        public string Username1 { get; set; }
        public string Username2 { get; set; }
        public IList<Message> User1Messages { get; set; }
        public IList<Message> User2Messages { get; set; }

    }
}
