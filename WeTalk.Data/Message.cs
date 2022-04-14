using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [ForeignKey("ApplicationUser"),Required]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string MessageContent { get; set; }
        [Required]
        public DateTimeOffset TimeStamp { get; set; }
        public DateTimeOffset EditedTimeStamp { get; set; }
        [ForeignKey("Conversation"),Required]
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
