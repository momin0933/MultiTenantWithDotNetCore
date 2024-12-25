using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class User:Base
    {
       // public int Id { get; set; }
        public string? ComputerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string UserLogin { get; set; } = null!;
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
