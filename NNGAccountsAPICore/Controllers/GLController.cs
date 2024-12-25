using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Controllers
{
  
    [ApiController]
    public class GLController : ControllerBase
    {
        private readonly IGLMst _IGLMst;
        //private readonly IDapperService _IDapperService;
        //private readonly NmlDbContext _dbContext;
        ICommonService _ICommonService;
        public GLController(IGLMst IGLMst)
        {
            _IGLMst = IGLMst;
            
            //_IDapperService = dapperService;
           // _ICommonService = new CommonRepository(_dbContext);
            // _IDapperService = new DapperService(dapperService)
            //_IDapperService = new CoreDapperService(ConnectionString.GetConnectionString);
        }
        [Route("api/GL")]
        [HttpGet]
        public List<GLMst> GetGlMstList()
        {
            try
            {
                List<GLMst> glMenuList = new List<GLMst>();

                glMenuList = _IGLMst.GetAllList();


                return glMenuList;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/GL")]
        [HttpPost]
        public int Post([FromBody] GLMst entity)
        {
            _IGLMst.AddGL(entity);
            return entity.Id;
        }
        [Route("api/GL")]
        [HttpPut]
        public int Update([FromBody] GLMst entity)
        {
            _IGLMst.UpdateGL(entity);
            return entity.Id;
        }
    }
}
