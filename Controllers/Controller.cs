using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace idata360.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Idata : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            Database db = new Database();
              
            //return 
             
        }
    }
}
