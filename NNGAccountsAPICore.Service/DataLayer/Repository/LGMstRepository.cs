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
    public class LGMstRepository : ILGMst
    {
        private readonly NmlDbContext _dbContext;
        private readonly IDapperService _IDapperService;
        ICommonService _ICommonService;
        public LGMstRepository(NmlDbContext dbContext, DapperService dapperService)
        {
            _dbContext = dbContext;
            _IDapperService = dapperService;
            _ICommonService = new CommonRepository(_dbContext);
        }
        public List<VwLGMst> GetAllList()
        {
            string Query = @"select * from VwLGwithGL ";
            var list = _IDapperService.GetAllByQuery<VwLGMst>(Query).ToList();
            return list;
        }
        public string GetLGCode(string GlId, string BuId)
        {
           
            string Query = @"SELECT
                            CASE WHEN MAX(Substring(LGID, 3, 2)) IS NULL THEN cast('01' as varchar(50)) ELSE '0' + cast((MAX(Substring(LGID, 3, 2)) + 1) as varchar(50)) END as MaxNo
                            FROM tblLGMst WHERE GLID = " + GlId + " AND BUID = " + BuId + " ";
            string GlCode = _IDapperService.GetStringByQuery(Query);
            string FullCode = GlId + GlCode + BuId;
            return FullCode;
        }
        public void AddLG(LGMst entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                _ICommonService.Add<LGMst>(entity);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateLG(LGMst entity)
        {
            try
            {
                //_dbContext.GLMsts.Add(entity);
                //_dbContext.SaveChanges();
                return _ICommonService.Update<LGMst>(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
