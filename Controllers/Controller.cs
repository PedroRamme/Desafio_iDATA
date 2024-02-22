using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace idata360.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Idata : ControllerBase
    {
        Database db = new Database();
        [HttpGet("recruitment")]            // endpoint
        public List<Recruitment> Get()
        {
               // Instanciando a classe Database

            return db.GetData();            // Retornando o metodo com os valores das linhas da tabela
             
        }

        [HttpPost("recruitment")] // Novo endpoint POST
        public IActionResult Post([FromBody] Recruitment recruitment)
        {
            // Verifica se o objeto recebido � v�lido
            if (recruitment == null)
            {
                return BadRequest("Dados de recrutamento inv�lidos.");
            }

            try
            {
                // Chama o m�todo InsertData para inserir os dados no banco
                bool result = db.InsertData(recruitment);

                if (result)
                {
                    return Ok("Dados inseridos com sucesso.");
                }
                else
                {
                    return BadRequest("Falha ao inserir os dados.");
                }
            }
            catch (System.Exception ex)
            {
                // Em caso de excecao, retorna um codigo de erro 500 com a mensagem de excecao
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
