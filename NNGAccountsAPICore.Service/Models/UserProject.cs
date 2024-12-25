using System;
using System.Collections.Generic;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
