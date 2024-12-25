using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Common;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Service;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class UserRepository : IUsers
    {
        readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        ICommonService _ICommonService;
        public UserRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;
            _ICommonService = new CommonRepository(_dbContext);
        }
        public List<VwUserDetails> GetProjectListByUser(int UserId)
        {
            SqlDataClass data = new SqlDataClass();
            var ProjectList = _IDapperService.GetAllByQuery<VwUserDetails>(data.GetUserInfo(UserId)).ToList();
            return ProjectList;
        }
        public User activeuser(User entity)
        {
            try
            {
                entity.UserPassword = EncryptDecrypt.Encrypt(entity.UserPassword);
                User userdetails = _dbContext.Users.Where(x => x.UserLogin == entity.UserLogin && x.UserPassword == entity.UserPassword).FirstOrDefault();
                return userdetails;
            }
            catch
            {
                throw;
            }
        }
        public List<User> GetUserList()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public User GetUserDetails(int id)
        {
            try
            {
                User? users = _dbContext.Users.Find(id);
                if (users != null)
                {
                    return users;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }


        public int AddUser(User entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                return _ICommonService.Add<User>(entity);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateUser(User entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                return _ICommonService.Update<User>(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
