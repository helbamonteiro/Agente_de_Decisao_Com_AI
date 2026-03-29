using AgenteDecisao.API.Models;

namespace AgenteDecisao.API.Tools
{
    //Ferramenta para cancelar a assinatura do cliente, que pode ser utilizada pelo agente de decisão
    public class FerramentaCancelar : IFerramentaAgente
    {
        public string Nome => "CANCELAR";

        public Task ExecutarAsync(ContextoDecisao contexto)
        {
            contexto.Assinatura.Status = "CANCELADA";

            return Task.CompletedTask;
        }
    }
}
