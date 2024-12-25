using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        ICommonService _ICommonService;
        public CategoryRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;
            _ICommonService = new CommonRepository(_dbContext);
        }
        public void AddCategory(CategoryClass entity)
        {
            try
            {               
                _ICommonService.Add<CategoryClass>(entity);
            }
            catch
            {
                throw;
            }
        }

        public List<CategoryClass> GetAllList()
        {
            return _ICommonService.GetAll<CategoryClass>().ToList();
        }

        public int UpdateCategory(CategoryClass entity)
        {
            try
            {                
                return _ICommonService.Update<CategoryClass>(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
