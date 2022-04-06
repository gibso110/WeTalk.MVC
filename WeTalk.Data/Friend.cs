using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTalk.Data
{
    public class Friend
    {
        [Key]
        public int FriendshipId { get; set; }
        //[ForeignKey("ApplicationUser"),Required]
        //public string User1Id { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("ApplicationUser2")]
        //public string User2Id { get; set; }
        //public virtual ApplicationUser ApplicationUser2 { get; set; }
        //[Required]
        //public DateTimeOffset FriendsSince { get; set; }
    }
}
