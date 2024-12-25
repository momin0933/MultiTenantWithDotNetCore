using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public interface IUserProject
    {      
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
