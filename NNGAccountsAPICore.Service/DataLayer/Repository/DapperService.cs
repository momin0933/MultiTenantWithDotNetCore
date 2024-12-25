using Dapper;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NNGAccountsAPICore.Service.DataLayer.Service;
using NNGAccountsCS;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class DapperService : IDapperService
    {
        // private string connectionString = ConfigurationManager.AppSettings["CS"];
        string connectionString = "";
        private IConfiguration Configuration;
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;
        public DapperService(ITenantService tenantService)
        {
            //Configuration = _configuration;
            //connectionString = Configuration.GetConnectionString("AccountsCS");
            _tenantService = tenantService;
            TenantId = _tenantService.GetTenant()?.TID;
        }
        
        public virtual IEnumerable<T> GetAllByQuery<T>(string query) where T : class
        {
            // ConnectionStringService connectionService = new ConnectionStringService();
            //SQLConnectionString connectionService = new SQLConnectionString();
            connectionString = _tenantService.GetConnectionString();
            //if (ProjectCS != "DefaultCS")
            //{
            //    // connectionString = Configuration.GetConnectionString(ProjectCS);
            //    connectionString = connectionService.GetConnectionString(ProjectCS);
            //}
           
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                //object o = JsonConvert.DeserializeObject(json1);
                //string json2 = JsonConvert.SerializeObject(o, Formatting.Indented);
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                SqlConnection1.Open();
                var q = SqlConnection1.Query<T>(query).ToList();
                dynamic collectionWrapper = new
                {
                    OEBuyerFactName = q
                };
                //serializer.MaxJsonLength = Int32.MaxValue;
                string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented); 
                //serializer.Serialize(collectionWrapper);

                return q;
            }
        }
        public virtual string GetStringByQuery(string query) 
        {          
            connectionString = _tenantService.GetConnectionString();          

            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {                
                SqlConnection1.Open();
                var q = SqlConnection1.QueryFirstOrDefault<string>(query);
                //dynamic collectionWrapper = new
                //{
                //    OEBuyerFactName = q
                //};
                ////serializer.MaxJsonLength = Int32.MaxValue;
                //string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
                ////serializer.Serialize(collectionWrapper);

                return q;
            }
        }

        //public IEnumerable<T> GetAllBySP<T>(string procedure, DynamicParameters p) where T : class
        //{
        //    using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
        //    {

        //        SqlConnection1.Open();
        //        JavaScriptSerializer jss = new JavaScriptSerializer();
        //        jss.MaxJsonLength = Int32.MaxValue;
        //        var q = SqlConnection1.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).ToList();
        //        dynamic collectionWrapper = new
        //        {
        //            OEBuyerFactName = q
        //        };
        //        string output = jss.Serialize(collectionWrapper);
        //        return q;
        //    }
        //}
        //public T GetByDynamicSPSingle<T>(string procedure, DynamicParameters p) where T:class
        //{
        //    using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
        //    {

        //        SqlConnection1.Open();
        //        var q = SqlConnection1.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //        dynamic collectionWrapper = new
        //        {
        //            OEBuyerFactName = q
        //        };
        //        string output = new JavaScriptSerializer().Serialize(collectionWrapper);

        //        return q;
        //    }
        //}
        //public int Post(string query)
        //{
        //    using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
        //    {
        //        SqlConnection1.Open();
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        var q = SqlConnection1.Execute(query);
        //        dynamic collectionWrapper = new
        //        {
        //            OEBuyerFactName = q
        //        };
        //        serializer.MaxJsonLength = Int32.MaxValue;
        //        string output = serializer.Serialize(collectionWrapper);

        //        return q;
        //    }
        //}
        //public void GetByMultipleQueryResult(string query, out string ReqQty, out string ActQty)
        //{
        //    using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
        //    {
        //        SqlConnection1.Open();
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        var q = SqlConnection1.QueryMultiple(query);
        //        ReqQty = q.Read<string>().Single();
        //        ActQty = q.Read<string>().Single();
        //        //dynamic collectionWrapper = new
        //        //{
        //        //    OEBuyerFactName = q
        //        //};
        //        //serializer.MaxJsonLength = Int32.MaxValue;
        //        //string output = serializer.Serialize(collectionWrapper);

        //        // return q;
        //    }
        //}
        //public int UpdateByQuery(string query)
        //{
        //    using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
        //    {
        //        SqlConnection1.Open();
        //        var q = SqlConnection1.Query(query);
        //        return 1;
        //    }
        //}
    }
}