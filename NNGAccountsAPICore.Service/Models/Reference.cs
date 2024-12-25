using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class Reference : Base
    {
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? CatID { get; set; }
        
    }
}
