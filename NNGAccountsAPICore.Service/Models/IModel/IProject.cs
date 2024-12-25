using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public interface IProject
    {
      
        public string? DatabaseName { get; set; }
        public string ProgramName { get; set; }
        public string? SqlserverName { get; set; }
        public string? SqluserName { get; set; }
        public string? Sqlpassword { get; set; }
        public string? DisplayCompanyName { get; set; }
        public string? DisplayCompanyAddress { get; set; }
        public string? DisplayCompanyPhone { get; set; }
        public string? DisplayCompanyRemark { get; set; }
        public int? OrderNo { get; set; }
        public string? PrjUrl { get; set; }
    }
}
