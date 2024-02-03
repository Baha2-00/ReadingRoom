using static ReadingRoom.Helper.Enum.Enums;

namespace ReadingRoom.DTOs.Subscription
{
    public class UpdateSubs
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float durationInDays { get; set; }
        public int DownloadedBookAmount { get; set; }
    }
}
