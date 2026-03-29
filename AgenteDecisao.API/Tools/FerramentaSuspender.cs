using AgenteDecisao.API.Models;

namespace AgenteDecisao.API.Tools
{
    //Ferramenta para suspender a assinatura do cliente, que pode ser utilizada pelo agente de decisão
    public class FerramentaSuspender : IFerramentaAgente
    {
        public string Nome => "SUSPENDER";

        public Task ExecutarAsync(ContextoDecisao contexto)
        {
            //MUDAR O STATUS DA ASSINATURA PARA SUSPENSA
            contexto.Assinatura.Status = "SUSPENSA";

            //LOGICA ADICIONAL PARA NOTIFICAR O CLIENTE, SE NECESSÁRIO
            return Task.CompletedTask;
        }
    }
}
