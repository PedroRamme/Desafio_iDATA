using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace idata360.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Idata : ControllerBase
    {
        [HttpGet]
        public List<Recruitment> Get()
        {
            Database db = new Database();

            return db.Get();
             
        }
    }
}
