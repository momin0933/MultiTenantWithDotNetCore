using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public interface IUser 
    {
        public string? ComputerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string UserLogin { get; set; }
        public string? Ipaddress { get; set; }
        public string? UserPassword { get; set; }
        public string? UserType { get; set; }
        public int? EmailUserId { get; set; }
        public int? CompId { get; set; }
        public string? DeptId { get; set; }
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public int ZoneId { get; set; }
        public string? Email { get; set; }
    }
}
