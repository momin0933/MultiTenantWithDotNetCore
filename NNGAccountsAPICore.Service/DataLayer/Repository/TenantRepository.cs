using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Service;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class TenantRepository : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private HttpContext _httpContext;
        private Tenant _currentTenant;
        public TenantRepository(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
                {
                    SetTenant(tenantId);
                }
                else
                {
                    // default tenant setup
                    SetTenant("default");
                   // throw new Exception("Invalid Tenant!");
                }
            }
        }
        private void SetTenant(string tenantId)
        {
           // var _tenantList = _tenantSettings.Tenants.ToList();
            SQLConnectionString sQLConnectionString = new SQLConnectionString();
            var _tenantList1 = sQLConnectionString.GetConnectionStringList();
            _currentTenant = _tenantList1.Where(a => a.TID == tenantId).FirstOrDefault();
            if (_currentTenant == null) throw new Exception("Invalid Tenant!");
            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }
        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentTenant.ConnectionString = _tenantSettings.Defaults.ConnectionString;
        }
        public string GetConnectionString()
        {
            return _currentTenant?.ConnectionString;
        }
        public string GetDatabaseProvider()
        {
            return _tenantSettings.Defaults?.DBProvider;
        }
        public Tenant GetTenant()
        {
            return _currentTenant;
        }
    }
}
