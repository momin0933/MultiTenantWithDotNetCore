using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Service
{
    public class ConnectionStringService
    {
        public string GetConnectionString(string  ProjectCsKey)
        {
            string CS = "";
            if(ProjectCsKey == "CSNMLProperty212201")
            {
                CS = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NMLProperty2122;Uid = sa; Password = aA@01737918236;";
            }
            return CS;
        }
    }
}
