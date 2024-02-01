using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Context;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public ClientController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }
    }
}
