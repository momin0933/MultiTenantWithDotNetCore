using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface IUsers
    {
      
        public List<VwUserDetails> GetProjectListByUser(int UserId);
        public User activeuser(User entity);
        public List<User> GetUserList();
        public User GetUserDetails(int id);
        public int AddUser(User entity);
        public int UpdateUser(User entity);
    }
}
