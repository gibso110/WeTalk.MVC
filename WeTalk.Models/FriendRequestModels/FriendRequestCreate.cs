using System.ComponentModel.DataAnnotations;

namespace WeTalk.Models.FriendRequestModels
{
    public class FriendRequestCreate
    {
        [Display(Name="Friends Username:")]
        public string Username { get; set; }
    }
}
