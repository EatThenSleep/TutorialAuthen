using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutorialAuthen.CookieAuthen.Attributes;

namespace TutorialAuthen.CookieAuthen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResourceController : ControllerBase
    {
        [HttpGet("Resource-Guest")]
        //[Authorize(Roles = "Guest")]
        [MaiPhuongAuthor("Guest", "Allowed")]
        public IActionResult getByGuest()
        {
            return Ok("Resource form guest");
        }

        [HttpGet("Resource-Admin")]
        //[Authorize(Roles = "Admin")]
        [MaiPhuongAuthor("Admin", "Allowed")]
        public IActionResult getByAdmin()
        {
            return Ok("Resource form admin");
        }

        [HttpGet("Resource-Administrator")]
        //[Authorize(Roles = "Administrator")]
        [MaiPhuongAuthor("Administrator", "Allowed")]
        public IActionResult getByAdministrator()
        {
            return Ok("Resource form administrator");
        }
    }
}
