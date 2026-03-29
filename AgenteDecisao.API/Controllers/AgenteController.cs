using AgenteDecisao.API.Agents;
using AgenteDecisao.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgenteDecisao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenteController(AgenteInadimpleciaDeClientes agente) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ContextoDecisao contexto)
        {
            var resultado = await agente.ExecutarAsync(contexto);

            return Ok(
                    new
                    {
                        resultado.Decisao,
                        resultado.Confianca,
                        resultado.Justificativa,
                        //Saber a ferramenta utilizada para chegar na decisão
                        NovoStatusAssinatura = contexto.Assinatura.Status
                    }
                );
        }
    }
}
