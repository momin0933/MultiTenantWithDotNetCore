using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NNGAccountsAPICore.Service.DataLayer.Common;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using NNGAccountsAPICore.Service.DataLayer.Service;
using NNGAccountsAPICore.Service.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NNGAccountsAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IDapperService _IDapperService;
        private readonly AccountsDbContext _context;

        public TokenController(IConfiguration config, AccountsDbContext context,DapperService dapperService)
        {
            _configuration = config;
            _context = context;
            _IDapperService = dapperService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User _userData)
        {
            if (_userData != null && _userData.UserLogin != null && _userData.UserPassword != null)
            {
                var user = await GetUser(_userData.UserLogin, _userData.UserPassword);

                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //create claims details based on the user information
                    var claims = new[] {

                        //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("UserLogin", user.UserLogin.ToString()),
                        //new Claim("FullName", user.FullName.ToString()),                       
                        //new Claim("Email", user.Email.ToString())
                        new Claim(ClaimTypes.NameIdentifier,user.UserLogin),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.GivenName,user.FullName),
                        //new Claim(ClaimTypes.Surname,user.FullName),
                        new Claim(ClaimTypes.Role,user.UserType),
                    };

                  
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: signIn);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string UserLogin, string UserPassword)
        {            

            UserPassword = EncryptDecrypt.Encrypt(UserPassword);

           // SqlDataClass sqlData = new SqlDataClass();
           // var UserProjectList = _IDapperService.GetAllByQuery<VwUserDetails>(sqlData.GetUserInfo(UserLogin, UserPassword));
           
            return await _context.Users.FirstOrDefaultAsync(u => u.UserLogin == UserLogin && u.UserPassword == UserPassword);
        }
    }
}
