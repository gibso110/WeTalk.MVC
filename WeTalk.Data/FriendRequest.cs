using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeTalk.Data
{
    public class FriendRequest
    {
        [Key]
        public int RequestId { get; set; }
        [ForeignKey("ApplicationUser"), Required]
        public string User1Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser2"), Required]
        public string User2Id { get; set; }
        public virtual ApplicationUser ApplicationUser2 { get; set; }
        [Required]
        public bool IsAccepted { get; set; } = false;
        [Required]
        public bool IsBlocked { get; set; } = false;
    }
}
