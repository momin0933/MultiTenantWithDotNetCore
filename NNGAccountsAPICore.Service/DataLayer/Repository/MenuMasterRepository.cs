using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class MenuMasterRepository : IMenuMaster
    {
        readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        public MenuMasterRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;
        }
        public List<VwMenuMaster> GetMenuMasterList(string LoginId)
        {
            try
            {
                List<VwMenuMaster> menuMasterList = new List<VwMenuMaster>();
                string Query = "";

                //if (PrjKey == "DefaultCS")
                //{
                //     Query = "SELECT * FROM MenuMaster";
                //}
                //else
                //{
                //    Query = @"  select distinct  me.ID as Id,right_name as Name,parent_id as ParentId,target_url as Url, 
                //                MenuIcon,ArrowIcon, serial_no as Sorting,isactive as IsActive 
                //                from tblUsers t
                //                left join TblUserRole ur on ur.UserID = t.ID
                //                left join tblRoleMenu rm on rm.role_id = ur.RoleID
                //                left join tblMenus me on me.ID = rm.right_id
                //                WHERE t.LoginID = '"+LoginId+"' order by me.serial_no ASC";
                //}
                Query = @"  select distinct  me.ID as Id,right_name as Name,parent_id as ParentId,target_url as Url, 
                                MenuIcon,ArrowIcon, serial_no as Sorting,isactive as IsActive 
                                from tblUsers t
                                left join TblUserRole ur on ur.UserID = t.ID
                                left join tblRoleMenu rm on rm.role_id = ur.RoleID
                                left join tblMenus me on me.ID = rm.right_id
                                WHERE t.LoginID = '" + LoginId + "' order by me.serial_no ASC";
                var menulist = _IDapperService.GetAllByQuery<VwMenuMaster>(Query).ToList();
                menuMasterList = menulist.FindAll(x => (x.ParentId == null) || (x.ParentId == 0)).ToList();
                foreach (VwMenuMaster item in menuMasterList)
                {
                    var ChildItemList = menulist.FindAll(x => x.ParentId == item.Id).ToList();
                    item.Childs = ChildItemList.ToList();
                }
                return menuMasterList;
            }
            catch
            {
                throw;
            }
        }

        public MenuMaster GetMenuMasterDetails(int id)
        {
            try
            {
                MenuMaster? MenuMasters = _dbContext.MenuMasters.Find(id);
                if (MenuMasters != null)
                {
                    return MenuMasters;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public void AddMenuMaster(MenuMaster employee)
        {
            try
            {
                _dbContext.MenuMasters.Add(employee);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateMenuMaster(MenuMaster employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public MenuMaster DeleteMenuMaster(int id)
        {
            try
            {
                MenuMaster? employee = _dbContext.MenuMasters.Find(id);

                if (employee != null)
                {
                    employee.IsActive = false;
                    _dbContext.Entry(employee).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }



       
    }
}

