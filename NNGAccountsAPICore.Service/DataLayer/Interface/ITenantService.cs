using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface ITenantService
    {
        public string GetDatabaseProvider();
        public string GetConnectionString();
        public Tenant GetTenant();
    }
}
