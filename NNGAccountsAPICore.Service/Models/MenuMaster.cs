using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class MenuMaster : Base
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentName { get; set; }
        public int? ParentId { get; set; } 
        public string? Url { get; set; }
        public string? MenuIcon { get; set; }
        public string? ArrowIcon { get; set; }
        public string? Sorting { get; set; }
       // public IList<MenuChild> Childs { get; set; }
    }
  
}
