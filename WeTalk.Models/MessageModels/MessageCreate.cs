using System;
using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.MessageModels
{
    public class MessageCreate
    {
        public int MessageId { get; set; }
        public string UserId { get; set; }
        [Display(Name ="Write message here:")]
        public string MessageContent { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int ConversationId { get; set; }
        [Display(Name ="Please enter the user this message is for")]
        public string Username { get; set; }

    }
}
