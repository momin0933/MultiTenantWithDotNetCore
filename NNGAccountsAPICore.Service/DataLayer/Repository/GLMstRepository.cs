using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class GLMstRepository : IGLMst
    {
        private readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        ICommonService _ICommonService;
        public GLMstRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;           
            _ICommonService = new CommonRepository(_dbContext);
        }
        public  List<GLMst> GetAllList()
        {
            //var list = _dbContext.MenuMasters.ToList();
            var list = _dbContext.GLMsts.ToList();
            return list;
        }
        public void AddGL(GLMst entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                _ICommonService.Add<GLMst>(entity);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateGL(GLMst entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                return _ICommonService.Update<GLMst>(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
