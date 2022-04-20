using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationDetail
    {
        [Display(Name="Your Username")]
        public string Username1 { get; set; }
        [Display(Name = "Friend's Username")]
        public string Username2 { get; set; }
        public IList<Message> User1Messages { get; set; }
        public IList<Message> User2Messages { get; set; }

    }
}
