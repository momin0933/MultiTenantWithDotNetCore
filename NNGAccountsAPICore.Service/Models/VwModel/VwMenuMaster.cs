using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class VwMenuMaster
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentName { get; set; }
        public int? ParentId { get; set; }
        public string? Url { get; set; }
        public string? MenuIcon { get; set; }
        public string? ArrowIcon { get; set; }
        public string? Sorting { get; set; }
        public bool? IsActive { get; set; }
        public List<VwMenuMaster> Childs { get; set; }
    }
}
