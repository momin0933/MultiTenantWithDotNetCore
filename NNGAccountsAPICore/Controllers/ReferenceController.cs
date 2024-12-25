using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;

namespace NNGAccountsAPICore.Controllers
{
    
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReference _IReference;
        ICommonService _ICommonService;
        public ReferenceController(IReference IReference)
        {
            _IReference = IReference;
        }
        [Route("api/Reference")]
        [HttpGet]
        public List<Reference> GetAll()
        {
            try
            {
                List<Reference> categoriesList = new List<Reference>();

                categoriesList = _IReference.GetAllList();


                return categoriesList;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/Reference")]
        [HttpPost]
        public int Post([FromBody] Reference entity)
        {
            _IReference.AddReference(entity);
            return entity.Id;
        }
        [Route("api/Reference")]
        [HttpPut]
        public int Update([FromBody] Reference entity)
        {
            _IReference.UpdateReference(entity);
            return entity.Id;
        }
        [Route("api/Reference/CompanyDate")]
        [HttpPut]
        public int CompanyDateUpdate([FromBody] CompanyDate entity)
        {
            _IReference.UpdateCompanyDate(entity);
            return entity.Id;
        }
        [Route("api/Reference/CompanyDate")]
        [HttpGet]
        public List<CompanyDate> GetAllCompanyDate()
        {
            try
            {
                List<CompanyDate> categoriesList = new List<CompanyDate>();

                categoriesList = _IReference.GetAllCompanyDateList();


                return categoriesList;
            }
            catch
            {
                throw;
            }
        }
    }
}
