using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class VwLGMst
    {
        public int Id { get; set; }
        public string? GLCode { get; set; }
        public string? GLID { get; set; }
        
        public string? GLHDName { get; set; }
        public string? AcClass { get; set; }
        public string? AcType { get; set; }
        public string? LGID { get; set; }
        public string? LGName { get; set; }
        public string? BUID { get; set; }
        public string? BUName { get; set; }

    }
}
