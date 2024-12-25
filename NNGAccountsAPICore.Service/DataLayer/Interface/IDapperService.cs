using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface IDapperService
    {
        IEnumerable<T> GetAllByQuery<T>(string query) where T : class;
        string GetStringByQuery(string query);
        //IEnumerable<T> GetAllBySP<T>(string procedure, DynamicParameters p) where T : class;
        //T GetByDynamicSPSingle<T>(string procedure, DynamicParameters p) where T : class;
        //int Post(string query);
        //int UpdateByQuery(string query);
        //void GetByMultipleQueryResult(string query, out string ReqQty, out string ActQty);
    }
}
