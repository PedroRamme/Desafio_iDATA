using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace idata360.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Idata : ControllerBase
    {
        [HttpGet("recruitment")]            // endpoint
        public List<Recruitment> Get()
        {
            Database db = new Database();   // Instanciando a classe Database

            return db.GetData();            // Retornando o metodo com os valores das linhas da tabela
             
        }
    }
}
