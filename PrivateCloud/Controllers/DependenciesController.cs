using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrivateCloud.Controllers
{
    [Route("cloud/api/[controller]")]
    [ApiController]
    public class DependenciesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test");
        }
    }
}
