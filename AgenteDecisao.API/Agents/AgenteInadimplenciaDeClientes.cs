using AgenteDecisao.API.Models;
using AgenteDecisao.API.Services;
using AgenteDecisao.API.Tools;
using System.Text.Json;

namespace AgenteDecisao.API.Agents
{
    /// <summary>
    /// Representa um agente responsável por gerenciar informações de inadimplência de clientes.
    /// E tomar decisões baseadas nessas informações, como enviar notificações, oferecer opções de pagamento,etc.
    /// </summary>
    public class AgenteInadimpleciaDeClientes(
        IServicoAI servicoAI, //Integração com os LLMs para processar informações e tomar decisões
        IEnumerable<IFerramentaAgente> ferramentasAgente //Ferramenta para executar as ações
        )
    {
        /// <summary>
        /// Método principal para processar o contexto de decisão 
        /// e tomar ações apropriadas com base nas informações 
        /// de inadimplência do cliente.
        /// </summary>
        private string ConstruirPrompt(ContextoDecisao contexto)
        {
            return $@"
                Você é um agente decisor corporativo.

                Regras obrigatórias:
                - Nunca cancelar se atraso < 60 dias
                - Suspender entre 60 e 120 dias
                - Cancelar acima de 120 dias

                Entrada do usuário: {contexto.EntradaUsuario}
                Cliente: {contexto.Cliente.Nome}
                Dias em atraso: {contexto.Cliente.DiasInadimplente}
                Status atual: {contexto.Assinatura.Status}

                Responda apenas JSON válido:
                {{
                  ""decisao"": ""SUSPENDER | CANCELAR | MANTER"",
                  ""confianca"": 0-1,
                  ""justificativa"": ""motivo""
                }}

                Não utilize markdown.
                Não utilize ```json.
                Não explique nada.
                Apenas retorne o objeto JSON.
            ";
        }

        /// <summary>
        /// Método para executar a lógica do agente, processando o contexto de decisão 
        /// e utilizando o serviço de AI para obter uma decisão.
        /// </summary>
        public async Task<ResultadoDecisao> ExecutarAsync(ContextoDecisao contexto)
        {
            //Construir o prompt para o modelo de AI
            var prompt = ConstruirPrompt(contexto);

            //Obter a resposta do modelo de AI
            var resposta = await servicoAI.ExecutarAsync(prompt);

            //Deserializar a resposta da IA
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ResultadoDecisao>(resposta, options);

            //Executar a ferramenta apropriada com base na decisão tomada
            await ExecutarFerramenta(resultado.Decisao, contexto);

            //Retornar o resultado da decisão
            return resultado;
        }

        /// <summary>
        /// Executar a ferramenta apropriada com base na decisão tomada, 
        /// como enviar notificações, suspender ou cancelar a assinatura do cliente.
        /// </summary>
        private async Task ExecutarFerramenta(string decisao, ContextoDecisao contexto)
        {
            //Encontrar a ferramenta correspondente à decisão tomada
            var ferramenta = ferramentasAgente.FirstOrDefault(f => f.Nome.Equals(decisao));
            if (ferramenta != null)
            {
                //Executar a ferramenta
                await ferramenta.ExecutarAsync(contexto);
            }
        }

    }
}