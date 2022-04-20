namespace WeTalk.Models.FriendRequestModels
{
    public class FriendRequestEdit
    {
        public int RequestId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsBlocked { get; set; }
        public string User2Id { get; set; }

    }
}
