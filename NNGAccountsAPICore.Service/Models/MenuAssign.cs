using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class MenuAssign :Base
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public int? MenuId { get; set; }
        public string? Permission { get; set; }
        //public string? CreatedBy { get; set; }
        //public DateTime? CreatedDt { get; set; }
        //public string? UpdatedBy { get; set; }
        //public DateTime? UpdatedDt { get; set; }
        //public bool? IsActive { get; set; }
    }
}
