using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Controllers
{
    [ApiController]
    public class MenuMasterController : ControllerBase
    {
        private readonly IMenuMaster _IMenuMaster;
        //private readonly IDapperService _IDapperService;
        //private readonly AccountsDbContext _dbContext;
        private readonly NmlDbContext _dbContext;
        ICommonService _ICommonService;
        public MenuMasterController(IMenuMaster IMenuMaster, NmlDbContext context)
        {
            _IMenuMaster = IMenuMaster;          
            _dbContext = context;
            //_IDapperService = dapperService;
            _ICommonService = new CommonRepository(_dbContext);
           // _IDapperService = new DapperService(dapperService)
            //_IDapperService = new CoreDapperService(ConnectionString.GetConnectionString);
        }

        [Route("api/MenuMaster")]
        [HttpGet]
        public IEnumerable<VwMenuMaster> Get([FromQuery] string LoginId)
        {           
            var MenuMasterList = _IMenuMaster.GetMenuMasterList(LoginId);
            return MenuMasterList;
        }       
        [Route("api/MenuMasterDetailsById")]
        [HttpGet]
        public MenuMaster MenuMasterDetailsById([FromQuery] int Id)
        {
            //var BList = _ICommonService.GetAll<Product>();
            var MenuMaster = _dbContext.MenuMasters.Where(x => x.Id == Id).FirstOrDefault();
            return MenuMaster;
        }

        [Route("api/MenuMaster")]
        [HttpPost]
        public int Post([FromBody] MenuMaster entity)
        {
            entity.IsActive = true;
            _ICommonService.Add(entity);
            return entity.Id;
        }
        [Route("api/MenuMaster")]
        [HttpPut]
        public int Update([FromBody] MenuMaster entity)
        {
          
            _ICommonService.Update(entity);
            return entity.Id;
        }
        [Route("api/MenuMaster/Remove")]
        [HttpPut]
        public int Remove([FromBody] MenuMaster entity)
        {           
            entity.IsActive = false;
            return _ICommonService.Update(entity);
        }
    }
}
