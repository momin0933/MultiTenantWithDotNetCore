using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface ICategory
    {
        public List<CategoryClass> GetAllList();      
        public void AddCategory(CategoryClass entity);
        public int UpdateCategory(CategoryClass entity);
       
    }
}
