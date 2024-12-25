using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Controllers
{


    public class LGController : ControllerBase
    {
        private readonly ILGMst _ILGMst;
        public LGController(ILGMst ILGMst)
        {
            _ILGMst = ILGMst;
        }
        [Route("api/LGCode")]
        [HttpGet]
        public LGMst GetLGCode(string GlId,string BuId)
        {
            try
            {
                LGMst lG = new LGMst();
                lG.LGID = _ILGMst.GetLGCode(GlId, BuId);
                lG.BUID = BuId;
                lG.GLID = GlId;
                return lG;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/LG")]
        [HttpGet]
        public List<VwLGMst> GetLGMstList()
        {
            try
            {
                List<VwLGMst> glMenuList = new List<VwLGMst>();

                glMenuList = _ILGMst.GetAllList();


                return glMenuList;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/LG")]
        [HttpPost]
        public int Post([FromBody] LGMst entity)
        {
            _ILGMst.AddLG(entity);
            return entity.Id;
        }
        [Route("api/LG")]
        [HttpPut]
        public int Update([FromBody] LGMst entity)
        {
            _ILGMst.UpdateLG(entity);
            return entity.Id;
        }
    }
}
