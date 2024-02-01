using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Context;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public AdminController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }
    }
}
