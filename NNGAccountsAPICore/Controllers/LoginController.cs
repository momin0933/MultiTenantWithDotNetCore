using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System.Security.Claims;

namespace NNGAccountsAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers _IUsers;

        public LoginController(IUsers IUser)
        {
            _IUsers = IUser;
        }
         [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminEndPoint()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.FullName}, You are Login as {currentuser.UserLogin} for {currentuser.UserType} User." );
        }
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userclaims = identity.Claims;
                return new User
                {
                    UserLogin = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    FullName = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    UserType = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
