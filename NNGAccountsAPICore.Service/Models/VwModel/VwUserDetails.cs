using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class VwUserDetails 
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }    
        public string UserLogin { get; set; } = null!;       
        public string? UserPassword { get; set; }
        public string? UserType { get; set; }     
        public bool IsActive { get; set; }
        public string? FullName { get; set; }

        //Project Information
        //public string? DatabaseName { get; set; }
        public string ProgramName { get; set; }
        //public string? SqlserverName { get; set; }
        //public string? SqluserName { get; set; }
        //public string? Sqlpassword { get; set; }
        public string? DisplayCompanyName { get; set; }
        public string? DisplayCompanyAddress { get; set; }
        public string? DisplayCompanyPhone { get; set; }
        public string? DisplayCompanyRemark { get; set; }
        public int? OrderNo { get; set; }
        public string? PrjUrl { get; set; }
        public string? PrjLogo { get; set; }
        public string? PrjKey { get; set; }

        //private string _ConnectionString = "";

        //public string ConnectionString
        //{
        //    get { return _ConnectionString = "Data Source= " + this.SqlserverName + "; Initial Catalog=" + this.DatabaseName + ";Uid= " + this.SqluserName + ";Password= " + this.Sqlpassword; }
        //    set { ConnectionString = value; }
        //}


    }
}
