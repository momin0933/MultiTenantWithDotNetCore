using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface ILGMst
    {
        public List<VwLGMst> GetAllList();
        string GetLGCode(string GlId, string BuId);
        //public GLMst GetGLById(int ID);
        public void AddLG(LGMst entity);
        public int UpdateLG(LGMst entity);
        //public MenuMaster DeleteGLMst(int ID);
    }
}
