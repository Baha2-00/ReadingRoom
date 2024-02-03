using Microsoft.AspNetCore.Http.HttpResults;
using ReadingRoom.DTOs.Authentication;
using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Person.Client;
using ReadingRoom.DTOs.Subscription;

namespace ReadingRoom.Interfaces
{
    public interface IShared
    {
        //Filltering 
        Task<List<GetSubDTO>> GetAllSubs();
        Task<List<GetSubDTO>> GetSubsFilter(float Price, float durationInDays, int Name);
        Task<List<GetContentDetailsDTO>> GetAllContent();
        Task<List<GetContentDetailsDTO>> GetContentDetails(float Price, int ContentType, string Name);
        //Regist
        Task CreateNewAccount(CreatClientDTO dto);
        //Login
        Task Login(Login dto);
        //ResetPassword
        Task ResetPassword(ResetPasswordDTO dto);
    }
}
