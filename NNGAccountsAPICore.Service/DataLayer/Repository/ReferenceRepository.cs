using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class ReferenceRepository : IReference
    {
        private readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        ICommonService _ICommonService;
        public ReferenceRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;
            _ICommonService = new CommonRepository(_dbContext);
        }
        public void AddReference(Reference entity)
        {
            try
            {
                _ICommonService.Add<Reference>(entity);
            }
            catch
            {
                throw;
            }
        }

        public List<Reference> GetAllList()
        {
            return _ICommonService.GetAll<Reference>().ToList();
           
        }

        public int UpdateReference(Reference entity)
        {
            try
            {
                return _ICommonService.Update<Reference>(entity);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateCompanyDate(CompanyDate entity)
        {
            try
            {
                return _ICommonService.Update<CompanyDate>(entity);
            }
            catch
            {
                throw;
            }
        }
        public List<CompanyDate> GetAllCompanyDateList()
        {
            return _ICommonService.GetAll<CompanyDate>().ToList();

        }
    }
}
