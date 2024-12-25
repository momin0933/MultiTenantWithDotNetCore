using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Common;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using NNGAccountsAPICore.Service.Models;
using System.Security.Claims;
using System.Web;
namespace NNGAccountsAPICore.Controllers
{
   
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUsers _IUsers;
        //private readonly AccountsDbContext _dbContext;
        //private readonly NmlDbContext _dbContext;
        //ICommonService _ICommonService;
        public UserController(IUsers IUsers)
        {
            _IUsers = IUsers;
            //_dbContext = context;
            //_ICommonService = new CommonRepository(_dbContext);
        }
      
        [Route("api/User/test")]
        [HttpGet]
        public string test()
        {
            return "API Connected sucessfully";
        }
        [Route("api/User")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //var BList = _ICommonService.GetAll<Product>();
            var UserList = _IUsers.GetUserList();
            return UserList;
        }
        [Route("api/User/ProjectList")]
        [HttpGet]
        public IEnumerable<VwUserDetails> GetProjectList([FromQuery] int UserId)
        {
            //var BList = _ICommonService.GetAll<Product>();
            var UserList = _IUsers.GetProjectListByUser(UserId);
            return UserList;
        }
        [Route("api/activeuser")]
        [HttpPost]
        public User activeuser(User entity)
        {
            var BList = _IUsers.activeuser(entity);

            //entity.UserPassword = EncryptDecrypt.Encrypt(entity.UserPassword);
            //User userdetails = _dbContext.Users.Where(x=> x.UserLogin == entity.UserLogin && x.UserPassword == entity.UserPassword).FirstOrDefault();
            return BList;
        }
        [Route("api/User/UserDetailsById")]
        [HttpGet]
        public User UserDetailsById([FromQuery] int Id)
        {
            var BList = _IUsers.GetUserDetails(Id);
            //var User = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            return BList;
        }

        [Route("api/User")]
        [HttpPost]
        public int Post([FromBody] User entity)
        {
            //entity.UserPassword = EncryptDecrypt.Encrypt(entity.UserPassword);
            //_ICommonService.Add(entity);         
            return _IUsers.AddUser(entity);
        }
        [Route("api/User")]
        [HttpPut]
        public int Update([FromBody] User entity)
        {

            //entity.UserPassword = EncryptDecrypt.Encrypt(entity.UserPassword);
            //_ICommonService.Update(entity);
            //return entity.Id;
            return _IUsers.UpdateUser(entity);
        }
        

    }
}
