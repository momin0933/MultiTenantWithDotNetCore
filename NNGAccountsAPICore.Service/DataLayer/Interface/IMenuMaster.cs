using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface IMenuMaster
    {
        public List<VwMenuMaster> GetMenuMasterList(string LoginId);
        public MenuMaster GetMenuMasterDetails(int id);
        public void AddMenuMaster(MenuMaster employee);
        public void UpdateMenuMaster(MenuMaster employee);
        public MenuMaster DeleteMenuMaster(int id);
       
    }
}
