using Microsoft.AspNetCore.Mvc;

namespace MeridiaCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public string Get() => "test";
    }
}
