using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    [Table("tblGLMst")]
    public class GLMst : Base
    {
        //[Key]
        //public int ID { get; set; }
        public string? GLCode { get; set; }
        public string? GLID { get; set; }
        public string? GLHDName { get; set; }
        public string? AcClass { get; set; }
        public string? AcType { get; set; }
        public decimal Opbal { get; set; }
        public decimal ClBal { get; set; }
        public int LSlNo { get; set; }
        public int? ClassID { get; set; }
    }
}
