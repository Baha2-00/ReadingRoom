using static ReadingRoom.Helper.Enum.Enums;

namespace ReadingRoom.Models.Entity
{
    public class Subscription
    {
        public int subscriptionId { get; set; }
        public SubscriptionType Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float durationInDays { get; set; }
        public int DownloadedBookAmount { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Person> Client { get; set; }
        public virtual List<Content> Contents { get; set; }
    }
}
