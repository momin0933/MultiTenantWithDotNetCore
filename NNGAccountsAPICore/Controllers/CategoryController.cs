using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Controllers
{
   
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _ICategory;
        ICommonService _ICommonService;
        public CategoryController(ICategory ICategory)
        {
            _ICategory = ICategory;           
        }
        [Route("api/Category")]
        [HttpGet]
        public List<CategoryClass> GetAll()
        {
            try
            {
                List<CategoryClass> categoriesList = new List<CategoryClass>();

                categoriesList = _ICategory.GetAllList();


                return categoriesList;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/Category")]
        [HttpPost]
        public int Post([FromBody] CategoryClass entity)
        {
            _ICategory.AddCategory(entity);
            return entity.Id;
        }
        [Route("api/Category")]
        [HttpPut]
        public int Update([FromBody] CategoryClass entity)
        {
            _ICategory.UpdateCategory(entity);
            return entity.Id;
        }
    }
}
