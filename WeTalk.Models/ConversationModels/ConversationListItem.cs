using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationListItem
    {
        public string UserName2 { get; set; }
        public IList<Message> User1Messages { get; set; }
        public IList<Message> User2Messages { get; set; }
    }
}
