using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Models.FriendModels
{
    public class FriendDetail
    {
        [Display(Name="Username")]
        public string UserName { get; set; }
        [Display(Name="Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Friends Since")]
        public DateTimeOffset FriendsSince { get; set; }
    }
}
