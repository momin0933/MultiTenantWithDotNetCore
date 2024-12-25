using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface IReference
    {
        public List<Reference> GetAllList();
        public void AddReference(Reference entity);
        public int UpdateReference(Reference entity);
        public int UpdateCompanyDate(CompanyDate entity);
        public List<CompanyDate> GetAllCompanyDateList();
    }
}
