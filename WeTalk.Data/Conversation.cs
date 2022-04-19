using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Data
{
    public class Conversation
    {
        [Key]
        public int ConversationId { get; set; }
        [ForeignKey("ApplicationUser"), Required]
        public string User1Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser2"), Required]
        public string User2Id { get; set; }
        public virtual ApplicationUser ApplicationUser2 { get; set; }
        [ForeignKey("Friend"), Required]
        public int FriendId { get; set; }
        public virtual Friend Friend { get; set; }

        public IList<Message> User1Message { get; set; }
        public IList<Message> User2Message { get; set; }
    }
}
