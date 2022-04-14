using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.MessageModels
{
    public class MessageDisplay
    {   [Display(Name="Username")]
        public string UserName { get; set; }
        [Display(Name = "Message:")]
        public string MessageContent { get; set; }
    }
}
