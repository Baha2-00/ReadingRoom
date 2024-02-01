using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Context;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public SharedController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }
    }
}
