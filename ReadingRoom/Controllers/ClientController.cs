using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Context;
using ReadingRoom.DTOs.Authentication;
using ReadingRoom.DTOs.Subscription;
using ReadingRoom.Interfaces;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase,IClient
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public  ClientController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }


        #region Register
        [HttpPut]
        [Route("[action]")]
        public Task<IActionResult> RegisterInSubAction(BuySubscriptionDTO dto)
        {
            throw new NotImplementedException();
            //try
            //{
            //    await Login(dto);
            //    return new ObjectResult(null) { StatusCode = 201, Value = "Login Success" };
            //}
            //catch (Exception ex)
            //{
            //    return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {ex.Message}" };
            //}
        }
        #endregion


        #region Implementation
        [NonAction]
        public Task RegisterInSub(BuySubscriptionDTO dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task DownloadBookSub(BuySubscriptionDTO dto)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
