﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class Base
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public bool? IsActive { get; set; }
    }
}
