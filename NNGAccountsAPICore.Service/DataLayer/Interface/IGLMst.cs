using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    
    public interface IGLMst
    {
        public List<GLMst> GetAllList();
        //public GLMst GetGLById(int ID);
        public void AddGL(GLMst entity);
        public int UpdateGL(GLMst entity);
        //public MenuMaster DeleteGLMst(int ID);
    }
}
