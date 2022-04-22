using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeTalk.Data;

namespace WeTalk.Models.ConversationModels
{
    public class ConversationListItem
    {
        [Display(Name="Username")]
        public string UserName2 { get; set; }
        public ICollection<Message> UserMessages { get; set; }
        public int ConversationId { get; set; }
    }
}
