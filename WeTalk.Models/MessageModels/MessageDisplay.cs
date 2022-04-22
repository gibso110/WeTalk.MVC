using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.MessageModels
{
    public class MessageDisplay
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Message:")]
        public string MessageContent { get; set; }
        public int MessageId { get; set; }
    }
}
