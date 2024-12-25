using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class Project 
    {
        public int Id { get; set; }
        public string? DatabaseName { get; set; }
        public string ProgramName { get; set; } = null!;
        public string? SqlserverName { get; set; }
        public string? SqluserName { get; set; }
        public string? Sqlpassword { get; set; }
        public string? DisplayCompanyName { get; set; }
        public string? DisplayCompanyAddress { get; set; }
        public string? DisplayCompanyPhone { get; set; }
        public string? DisplayCompanyRemark { get; set; }
        public int? OrderNo { get; set; }
        public string? PrjUrl { get; set; }
        public string? PrjKey { get; set; }
        public string? PrjLogo { get; set; }
    }
}
