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
        public int FriendshipId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
