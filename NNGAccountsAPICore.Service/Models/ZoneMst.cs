using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class ZoneMst
    {
        public string Zid { get; set; } = null!;
        public string? Zname { get; set; }
        public int? SuperId { get; set; }
        public int? CsuperId { get; set; }
        public string? SzdPass { get; set; }
    }
}
