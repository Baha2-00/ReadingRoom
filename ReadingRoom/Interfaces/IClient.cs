using ReadingRoom.DTOs.Authentication;
using ReadingRoom.DTOs.Subscription;

namespace ReadingRoom.Interfaces
{
    public interface IClient
    {
        Task RegisterInSub(BuySubscriptionDTO dto);
        //Task DownloadBookSub(BuySubscriptionDTO dto);
    }
}
