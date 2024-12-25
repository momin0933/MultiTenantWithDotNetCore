using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NNGAccountsAPICore.Controllers
{
   
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("api/test")]
        [HttpGet]
        public string test()
        {
            return "API Connected sucessfully";
        }
    }
}
