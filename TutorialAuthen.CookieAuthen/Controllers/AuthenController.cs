using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TutorialAuthen.CookieAuthen.Models;

namespace TutorialAuthen.CookieAuthen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnAuthorized()
        {
            return Unauthorized();
        }
        [HttpGet("unauthorized-v2")]
        public IActionResult GetUnAuthorizedV2()
        {
            return Unauthorized();
        }

        [HttpGet("forbidden")]
        public HttpResponseMessage GetForbidden()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequestModel request)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role, request.Role),
                new Claim("FullName", "Công Viên")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                           principal, authProperties);
            return Ok("Login success with cookie");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Logout succes with cookie");
        }
    }
}

