using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Service
{
    public class SQLConnectionString
    {
        public string ProjectCS { get; set; }
        public string ApiKey { get; set; }
        public string GetConnectionString(string ProjectCsKey)
        {
            string CS = "";
            if (ProjectCsKey == "CSNMLProperty2122")
            {
                CS = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NMLProperty2122;Uid = sa; Password = aA@01737918236;";
            }
            return CS;
        }
        public List<Tenant> GetConnectionStringList()
        {
            List<Tenant> tenantList = new List<Tenant>();
            Tenant tenant = new Tenant();

            tenant.TID = "default";
            tenant.Name = "default";
            tenant.ConnectionString = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NNGAccounts;Uid = sa; Password = aA@01737918236;";
            tenantList.Add(tenant);

            tenant = new Tenant();
            tenant.TID = "CSNMLProperty2122";
            tenant.Name = "CSNMLProperty2122";
            tenant.ConnectionString = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NMLProperty2223;Uid = sa; Password = aA@01737918236;";
            tenantList.Add(tenant);

            return tenantList;

        }
    }
    //public class Tenant
    //{
    //    public string Name { get; set; }
    //    public string TID { get; set; }
    //    public string ConnectionString { get; set; }
    //}
}
